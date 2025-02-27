using Assets.Scripts.BoardGeneration;
using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Command;
using Assets.Scripts.Quiz;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public sealed class PlayerViewModel : IPlayerViewModel
    {
        private readonly IBoardModel _boardModel;
        private readonly IPlayerState _playerState;
        private ICommandDispatcher _commandDispatcher;

        public Action<int> OnPlayerMove { get; set; }

        public bool IsMoving => _playerState.IsMoving;
        public List<ITile> Tiles => _boardModel.Tiles;

        public PlayerViewModel(
            IBoardModel boardModel,
            IPlayerState playerState,
            ICommandDispatcher commandDispatcher)
        {
            _boardModel = boardModel;
            _playerState = playerState;
            _commandDispatcher = commandDispatcher;
        }

        public void MovePlayer(int steps)
        {
            if (IsMoving)
                return;

            if (Tiles is null || Tiles.Count == 0)
                return;

            _playerState.IsMoving = true;
            OnPlayerMove?.Invoke(steps);
        }

        public void OnMovementEnded(bool shouldShowQuiz)
        {
            _playerState.IsMoving = false;

            if (shouldShowQuiz)
                _commandDispatcher.Execute(new ShowQuizCommand());
        }
    }
}