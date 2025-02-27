namespace Assets.Scripts.Score
{
    public sealed class ScoreModel : IScoreModel
    {
        public int Score { get; set; }

        public void UpdateScore(int score)
        {
            Score += score;
        }
    }
}