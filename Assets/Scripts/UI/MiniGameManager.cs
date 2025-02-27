using Assets.Scripts.Quiz;
using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts.UI
{
    public sealed class MiniGameManager : IMiniGameManager
    {
        public Action<int> OnShowMiniGame { get; set; }

        public void ShowMiniGame()
        {
            var quizTypesCount = Enum.GetNames(typeof(QuizType)).Length;
            var selectedQuiz = Random.Range(0, quizTypesCount);

            OnShowMiniGame?.Invoke(1);
        }
    }
}