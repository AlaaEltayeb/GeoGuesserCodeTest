using Assets.Scripts.Quiz;
using Assets.Scripts.Score;
using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts.MiniGame
{
    public sealed class MiniGameViewModel : IMiniGameViewModel
    {
        public Action<int> OnShowMiniGame { get; set; }
        public Action<int, QuizData, bool> OnShowMiniGameResult { get; set; }

        private readonly IScoreModel _scoreModel;

        public MiniGameViewModel(IScoreModel scoreModel)
        {
            _scoreModel = scoreModel;
        }

        public void ShowMiniGame()
        {
            var quizTypesCount = Enum.GetNames(typeof(QuizType)).Length;
            var selectedQuiz = Random.Range(0, quizTypesCount);

            OnShowMiniGame?.Invoke(selectedQuiz);
        }

        public void ShowMiniGameResult(int score, QuizData quizData, bool succeeded)
        {
            if (succeeded)
                _scoreModel.UpdateScore(score);

            OnShowMiniGameResult?.Invoke(score, quizData, succeeded);
        }
    }
}