using Assets.Scripts.BoardGeneration.BoardPatterns;

namespace Assets.Scripts.MainMenu
{
    public interface IMainMenuViewModel
    {
        void OnStart(
            int size,
            int quizTilesPercentage,
            BoardPatternType patternType);
    }
}