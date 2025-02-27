using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.UI
{
    public sealed class MiniGameView : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _miniGames;

        [SerializeField]
        private List<TextAsset> _textAssets;

        [Inject]
        private void Constructor(IMiniGameModel miniGameModel, IMiniGameManager miniGameManager)
        {
            miniGameModel.GenerateQuizzes(_textAssets);
            miniGameManager.OnShowMiniGame += ShowSelectedMiniGame;
        }

        private void ShowSelectedMiniGame(int selectedMiniGame)
        {
            _miniGames[selectedMiniGame].SetActive(true);
        }
    }
}