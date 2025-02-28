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

        private IFloatingScoreViewModel _floatingScoreViewModel;

        [Inject]
        private void Constructor(IFloatingScoreViewModel floatingScoreViewModel)
        {
            _floatingScoreViewModel = floatingScoreViewModel;
            _floatingScoreViewModel.OnFloatingScore += OnFloatingScore;
        }

        private void OnFloatingScore(int score)
        {
            _scoreText.text = score.ToString();
            if (_floatingTextAnimator != null)
                _floatingTextAnimator.SetTrigger("Play");
        }

        private void OnDestroy()
        {
            if (_floatingScoreViewModel == null)
                return;

            _floatingScoreViewModel.OnFloatingScore -= OnFloatingScore;
        }
    }
}