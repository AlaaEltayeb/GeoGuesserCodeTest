using Assets.Scripts.Command;
using Assets.Scripts.UI;
using VContainer;

namespace Assets.Scripts.Quiz
{
    public sealed class ShowQuizCommand : ICommand
    {
        private IMiniGameManager _miniGameManager;

        [Inject]
        private void Constructor(IMiniGameManager miniGameManager)
        {
            _miniGameManager = miniGameManager;
        }

        public void Execute()
        {
            _miniGameManager.ShowMiniGame();
        }
    }
}