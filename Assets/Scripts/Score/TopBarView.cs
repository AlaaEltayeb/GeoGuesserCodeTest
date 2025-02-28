using TMPro;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Score
{
    public sealed class TopBarView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        private ITopBarViewModel _topBarViewModel;

        [Inject]
        private void Constructor(ITopBarViewModel topBarViewModel)
        {
            _topBarViewModel = topBarViewModel;
            _topBarViewModel.OnScoreUpdated += OnScoreUpdated;
        }

        private void OnScoreUpdated(int score)
        {
            _scoreText.text = score.ToString();
        }

        private void OnDestroy()
        {
            if (_topBarViewModel == null)
                return;

            _topBarViewModel.OnScoreUpdated -= OnScoreUpdated;
        }
    }
}