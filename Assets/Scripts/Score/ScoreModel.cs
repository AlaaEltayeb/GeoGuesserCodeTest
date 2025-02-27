using System;

namespace Assets.Scripts.Score
{
    public sealed class ScoreModel : IScoreModel
    {
        public int Score { get; set; }
        public Action OnScoreUpdated { get; set; }

        public void UpdateScore(int score)
        {
            Score += score;
            OnScoreUpdated?.Invoke();
        }
    }
}