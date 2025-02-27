using Assets.Scripts.Command;
using Assets.Scripts.MiniGame;
using VContainer;

namespace Assets.Scripts.Quiz
{
    public sealed class ShowQuizCommand : ICommand
    {
        private IMiniGameViewModel _miniGameViewModel;

        [Inject]
        private void Constructor(IMiniGameViewModel miniGameViewModel)
        {
            _miniGameViewModel = miniGameViewModel;
        }

        public void Execute()
        {
            _miniGameViewModel.ShowMiniGame();
        }
    }
}