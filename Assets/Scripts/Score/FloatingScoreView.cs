using TMPro;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Score
{
    public sealed class FloatingScoreView : MonoBehaviour
    {
        [SerializeField]
        private Animator _floatingTextAnimator;
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        [Inject]
        private void Constructor(IFloatingScoreViewModel floatingScoreViewModel)
        {
            floatingScoreViewModel.OnFloatingScore += score =>
            {
                _scoreText.text = score.ToString();
                _floatingTextAnimator.SetTrigger("Play");
            };
        }
    }
}