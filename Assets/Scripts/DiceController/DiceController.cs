using Assets.Scripts.Command;
using Assets.Scripts.Player;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.DiceController
{
    public sealed class DiceController : MonoBehaviour, IDiceController
    {
        [SerializeField]
        private int _minDiceCount = 1;
        [SerializeField]
        private int _maxDiceCount = 7;

        private IPlayerState _playerState;
        private ICommandDispatcher _commandDispatcher;

        [Inject]
        private void Constructor(IPlayerState playerState, ICommandDispatcher commandDispatcher)
        {
            _playerState = playerState;
            _commandDispatcher = commandDispatcher;
        }

        public void RollDice()
        {
            if (_playerState.IsMoving)
                return;

            var stepsCount = Random.Range(_minDiceCount, _maxDiceCount);
            _commandDispatcher.Execute(new MoveCommand(stepsCount));
        }
    }
}