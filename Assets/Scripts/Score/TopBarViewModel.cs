using System;

namespace Assets.Scripts.Score
{
    public sealed class TopBarViewModel : ITopBarViewModel
    {
        public Action<int> OnScoreUpdated { get; set; }

        public TopBarViewModel(IScoreModel scoreModel)
        {
            scoreModel.OnScoreUpdated += () => OnScoreUpdated?.Invoke(scoreModel.Score);
        }
    }
}