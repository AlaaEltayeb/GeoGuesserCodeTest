using Assets.Scripts.Command;
using Assets.Scripts.Player;
using UnityEngine;

namespace Assets.Scripts.DiceController
{
    public sealed class DiceViewModel : IDiceViewModel
    {
        private readonly IPlayerState _playerState;
        private readonly ICommandDispatcher _commandDispatcher;

        public DiceViewModel(IPlayerState playerState, ICommandDispatcher commandDispatcher)
        {
            _playerState = playerState;
            _commandDispatcher = commandDispatcher;
        }

        public void RollDice(int minDiceCount, int maxDiceCount)
        {
            if (_playerState.IsMoving)
                return;

            var stepsCount = Random.Range(minDiceCount, maxDiceCount);
            _commandDispatcher.Execute(new MoveCommand(stepsCount));
        }
    }
}