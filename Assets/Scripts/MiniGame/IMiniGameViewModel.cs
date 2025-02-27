using Assets.Scripts.Quiz;
using System;

namespace Assets.Scripts.MiniGame
{
    public interface IMiniGameViewModel
    {
        Action<int> OnShowMiniGame { get; set; }
        Action<int, QuizData, bool> OnShowMiniGameResult { get; set; }

        void ShowMiniGame();
        void ShowMiniGameResult(int score, QuizData quizData, bool succeeded);
    }
}