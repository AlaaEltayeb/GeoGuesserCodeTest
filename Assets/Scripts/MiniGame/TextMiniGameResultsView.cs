using TMPro;
using UnityEngine;

namespace Assets.Scripts.MiniGame
{
    public sealed class TextMiniGameResultsView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _resultText;

        [SerializeField]
        private TextMeshProUGUI _correctAnswerText;
    }
}