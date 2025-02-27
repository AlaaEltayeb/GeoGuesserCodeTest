using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.MiniGame
{
    public sealed class MiniGameView : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> _miniGames;

        [Inject]
        private void Constructor(IMiniGameManager miniGameManager)
        {
            miniGameManager.OnShowMiniGame += ShowSelectedMiniGame;
        }

        private void ShowSelectedMiniGame(int selectedMiniGame)
        {
            _miniGames[selectedMiniGame].SetActive(true);
        }
    }
}