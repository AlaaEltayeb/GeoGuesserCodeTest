using System;
using Random = UnityEngine.Random;

namespace Assets.Scripts.Score
{
    public sealed class FloatingScoreViewModel : IFloatingScoreViewModel
    {
        private const int MinScore = 5;
        private const int MaxScore = 11;

        private int _score;

        public Action<int> OnFloatingScore { get; set; }

        private readonly IScoreModel _scoreModel;

        public FloatingScoreViewModel(IScoreModel scoreModel)
        {
            _scoreModel = scoreModel;
        }

        public void ShowFloatingScore()
        {
            _score = Random.Range(MinScore, MaxScore);
            _scoreModel.UpdateScore(_score);

            OnFloatingScore?.Invoke(_score);
        }
    }
}