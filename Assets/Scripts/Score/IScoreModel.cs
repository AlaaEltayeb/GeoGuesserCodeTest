using System;

namespace Assets.Scripts.Score
{
    public interface IScoreModel
    {
        int Score { get; set; }
        Action OnScoreUpdated { get; set; }

        void UpdateScore(int score);
    }
}