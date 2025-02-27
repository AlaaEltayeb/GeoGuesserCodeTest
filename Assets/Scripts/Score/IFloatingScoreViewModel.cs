using System;

namespace Assets.Scripts.Score
{
    public interface IFloatingScoreViewModel
    {
        Action<int> OnFloatingScore { get; set; }

        void ShowFloatingScore();
    }
}