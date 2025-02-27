using System;

namespace Assets.Scripts.Score
{
    public interface ITopBarViewModel
    {
        Action<int> OnScoreUpdated { get; set; }
    }
}