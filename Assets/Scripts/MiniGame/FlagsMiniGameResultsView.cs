using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MiniGame
{
    public class FlagsMiniGameResultsView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _resultText;

        [SerializeField]
        private TextMeshProUGUI _correctAnswerText;

        [SerializeField]
        private Image _questionImage;
    }
}