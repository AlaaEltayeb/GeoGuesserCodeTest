using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Player;
using System.Collections.Generic;
using VContainer;

namespace Assets.Scripts.Command
{
    public class MoveCommand : ICommand
    {
        private readonly int _steps;
        private readonly List<ITile> _tiles;
        private IPlayerController _playerController;

        public MoveCommand(int steps)
        {
            _steps = steps;
        }

        [Inject]
        private void Constructor(IPlayerController playerController)
        {
            _playerController = playerController;
        }

        public void Execute()
        {
            _playerController.MovePlayer(_steps);
        }
    }
}