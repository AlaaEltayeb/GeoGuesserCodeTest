using TMPro;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.Score
{
    public sealed class TopBarView : MonoBehaviour
    {
        [SerializeField]
        private TextMeshProUGUI _scoreText;

        [Inject]
        private void Constructor(ITopBarViewModel topBarViewModel)
        {
            topBarViewModel.OnScoreUpdated += score => { _scoreText.text = score.ToString(); };
        }
    }
}