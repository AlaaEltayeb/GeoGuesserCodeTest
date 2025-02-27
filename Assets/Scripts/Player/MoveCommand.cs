using Assets.Scripts.Command;
using VContainer;

namespace Assets.Scripts.Player
{
    public class MoveCommand : ICommand
    {
        private readonly int _steps;
        private IPlayerViewModel _playerViewModel;

        public MoveCommand(int steps)
        {
            _steps = steps;
        }

        [Inject]
        private void Constructor(IPlayerViewModel playerViewModel)
        {
            _playerViewModel = playerViewModel;
        }

        public void Execute()
        {
            _playerViewModel.MovePlayer(_steps);
        }
    }
}