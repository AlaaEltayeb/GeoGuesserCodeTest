using Assets.Scripts.BoardGeneration;
using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Command;
using Assets.Scripts.Quiz;
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
        private List<ITile> _tiles;

        private IPlayerState _playerState;
        private ICommandDispatcher _commandDispatcher;

        [Inject]
        private void Constructor(
            IPlayerState playerState,
            IBoardModel boardModel,
            IPlayerController playerController,
            ICommandDispatcher commandDispatcher)
        {
            _playerState = playerState;
            _tiles = boardModel.Tiles;
            _playerController = playerController;
            _commandDispatcher = commandDispatcher;
            _playerController.OnPlayerMove += MovePlayer;

            if (_tiles is null)
                return;

            transform.position = boardModel.Tiles[0].TileData.Position;
        }

        private void MovePlayer(int steps)
        {
            if (_playerState.IsMoving)
                return;

            if (_tiles is null)
                return;

            _playerState.IsMoving = true;
            _playerTargetPositionIndex = _playerCurrentPositionIndex;
            _playerTargetPositionIndex += steps;
            MovePlayerAsync();
        }

        private void MovePlayerAsync()
        {
            if (_playerCurrentPositionIndex >= _playerTargetPositionIndex)
            {
                _playerState.IsMoving = false;
                if (_tiles[_playerCurrentPositionIndex] is QuizTile)
                {
                    _commandDispatcher.Execute(new ShowQuizCommand());
                }

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

            MovePlayerAsync();
        }
    }
}