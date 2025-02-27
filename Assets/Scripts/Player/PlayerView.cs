using Assets.Scripts.BoardGeneration.Tiles;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Player
{
    public sealed class PlayerView : MonoBehaviour
    {
        [SerializeField]
        private float _moveCooldown = 1;
        [SerializeField]
        private Animator _playerAnimator;
        [SerializeField]
        private ParticleSystem _particleSystem;
        [SerializeField]
        private Animator _floatingTextAnimator;

        private int _playerCurrentPositionIndex;
        private int _playerTargetPositionIndex;

        private List<ITile> _tiles;

        private IPlayerViewModel _playerViewModel;

        [Inject]
        private void Constructor(IPlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
            playerViewModel.OnPlayerMove += OnMovementStarted;

            _tiles = _playerViewModel.Tiles;

            if (_tiles is null || _tiles.Count == 0)
                return;

            transform.position = _tiles[0].TileData.Position;
        }

        private void OnMovementStarted(int steps)
        {
            if (_tiles is null)
                return;

            _playerAnimator.speed = 1 / _moveCooldown;
            _playerTargetPositionIndex = _playerCurrentPositionIndex;
            _playerTargetPositionIndex += steps;
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (_playerCurrentPositionIndex >= _playerTargetPositionIndex)
            {
                _playerViewModel.OnMovementEnded(_tiles[_playerCurrentPositionIndex] is QuizTile);

                return;
            }

            _playerCurrentPositionIndex++;
            if (_playerCurrentPositionIndex >= _tiles.Count)
            {
                _playerCurrentPositionIndex = 0;
                _playerTargetPositionIndex -= _tiles.Count;
            }

            _playerAnimator.SetTrigger("Jump");

            var target = _tiles[_playerCurrentPositionIndex].TileData.Position;
            transform
                .DOMove(target, _moveCooldown)
                .SetEase(Ease.InOutSine)
                .onComplete = OnAnimationCompleted;
        }

        private void OnAnimationCompleted()
        {
            if (_tiles[_playerCurrentPositionIndex] is EmptyTile)
            {
                _particleSystem.Play();
                _floatingTextAnimator.SetTrigger("Play");
            }

            MovePlayer();
        }
    }
}