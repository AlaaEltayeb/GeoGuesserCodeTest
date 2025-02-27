using Assets.Scripts.Command;
using Assets.Scripts.Quiz;
using VContainer;

namespace Assets.Scripts.MiniGame
{
    public sealed class ShowMiniGameResultCommand : ICommand
    {
        private readonly int _score;
        private readonly QuizData _quizData;
        private readonly bool _succeeded;

        private IMiniGameViewModel _miniGameViewModel;

        public ShowMiniGameResultCommand(int score, QuizData quizData, bool succeeded)
        {
            _score = score;
            _quizData = quizData;
            _succeeded = succeeded;
        }

        [Inject]
        private void Constructor(IMiniGameViewModel miniGameViewModel)
        {
            _miniGameViewModel = miniGameViewModel;
        }

        public void Execute()
        {
            _miniGameViewModel.ShowMiniGameResult(_score, _quizData, _succeeded);
        }
    }
}