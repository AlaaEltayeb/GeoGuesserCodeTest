using Assets.Scripts.Player;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Command
{
    public sealed class SetInitialPlayerPositionCommand : ICommand
    {
        private readonly Vector3 _position;
        private IPlayerController _playerController;

        public SetInitialPlayerPositionCommand(Vector3 position)
        {
            _position = position;
        }

        [Inject]
        private void Constructor(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Execute()
        {
            _playerController.SetInitialPosition(_position);
        }
    }
}