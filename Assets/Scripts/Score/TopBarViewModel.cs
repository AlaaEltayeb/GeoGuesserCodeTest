using System;

namespace Assets.Scripts.Score
{
    public sealed class TopBarViewModel : ITopBarViewModel
    {
        public Action<int> OnScoreUpdated { get; set; }

        private readonly IScoreModel _scoreModel;

        public TopBarViewModel(IScoreModel scoreModel)
        {
            _scoreModel = scoreModel;
            _scoreModel.OnScoreUpdated += UpdateScore;
        }

        private void UpdateScore()
        {
            OnScoreUpdated?.Invoke(_scoreModel.Score);
        }

        private void OnDestroy()
        {
            if (_scoreModel == null)
                return;

            _scoreModel.OnScoreUpdated -= UpdateScore;
        }
    }
}