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

        [Inject]
        private void Constructor(IMiniGameViewModel miniGameViewModel)
        {
            miniGameViewModel.OnShowMiniGame += ShowSelectedMiniGame;
        }

        private void ShowSelectedMiniGame(int selectedMiniGameType)
        {
            _miniGames[selectedMiniGameType].SetActive(true);

            var quizViews = _miniGames.Select(miniGame => miniGame.GetComponent<QuizViewBase>()).ToList();

            var selectedMiniGame = quizViews
                .FirstOrDefault(miniGame => (int)miniGame.QuizType == selectedMiniGameType);

            selectedMiniGame!.Populate();
        }
    }
}