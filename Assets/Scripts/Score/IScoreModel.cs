namespace Assets.Scripts.Score
{
    public interface IScoreModel
    {
        int Score { get; set; }

        void UpdateScore(int score);
    }
}