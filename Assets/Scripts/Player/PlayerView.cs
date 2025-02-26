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
        private Animator _playerAnimator;
        [SerializeField]
        private ParticleSystem _particleSystem;
        [SerializeField]
        private Animator _floatingTextAnimator;

        private IPlayerController _playerController;

        private bool _isMoving;
        private int _playerCurrentPositionIndex;
        private int _playerTargetPositionIndex;

        private float _moveCooldown = 1;
        private int _steps;
        private List<ITile> _tiles;

        [Inject]
        private void Constructor(IPlayerController playerController)
        {
            _playerController = playerController;
            _playerController.OnPlayerInitialize += InitializePlayer;
            _playerController.OnPlayerMove += MovePlayer;
        }

        public void InitializePlayer(Vector3 position)
        {
            transform.position = position;
        }

        private void MovePlayer(int steps, List<ITile> tiles)
        {
            if (_isMoving)
                return;

            Debug.Log($"Moving: {steps} Steps");
            _steps = steps;
            _tiles = tiles;
            _playerTargetPositionIndex = _playerCurrentPositionIndex;
            _playerTargetPositionIndex += steps;
            MovePlayerAsync();
        }

        private void MovePlayerAsync()
        {
            if (_playerCurrentPositionIndex >= _playerTargetPositionIndex)
            {
                _isMoving = false;
                return;
            }

            if (_tiles[_playerCurrentPositionIndex] is EmptyTile)
            {
                _particleSystem.Play();
                _floatingTextAnimator.SetTrigger("Play");
            }

            _playerCurrentPositionIndex++;
            if (_playerCurrentPositionIndex >= _tiles.Count)
            {
                _playerCurrentPositionIndex = 0;
                _playerTargetPositionIndex -= _tiles.Count;
            }

            _playerAnimator.SetTrigger("Jump");

            var target = _tiles[_playerCurrentPositionIndex].Position;
            transform
                .DOMove(target, _moveCooldown)
                .SetEase(Ease.InOutSine)
                .onComplete = MovePlayerAsync;
        }
    }
}