using Assets.Scripts.Quiz;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.MiniGame
{
    public sealed class MiniGameView : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _miniGames;
        [SerializeField]
        private List<GameObject> _miniGameResult;

        [Inject]
        private void Constructor(IMiniGameViewModel miniGameViewModel)
        {
            miniGameViewModel.OnShowMiniGame += ShowSelectedMiniGame;
            miniGameViewModel.OnShowMiniGameResult += ShowMiniGameResult;
        }

        private void ShowSelectedMiniGame(int selectedMiniGameType)
        {
            var quizViews = _miniGames
                .Select(miniGame => miniGame.GetComponent<QuizViewBase>())
                .ToList();

            var selectedMiniGame = quizViews
                .FirstOrDefault(miniGame => (int)miniGame.QuizType == selectedMiniGameType);

            selectedMiniGame!.Populate();
        }

        private void ShowMiniGameResult(int score, QuizData quizData, bool succeeded)
        {
            var quizResultsViews = _miniGameResult
                .Select(miniGame => miniGame.GetComponent<QuizResultViewBase>())
                .ToList();

            var selectedMiniGameResult = quizResultsViews
                .FirstOrDefault(miniGame => (int)miniGame.QuizType == quizData.QuestionType);

            selectedMiniGameResult!.Populate(score, quizData, succeeded);
        }
    }
}