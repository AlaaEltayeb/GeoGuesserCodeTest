using Assets.Scripts.BoardGeneration;
using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.Command;
using Assets.Scripts.SceneLoading;

namespace Assets.Scripts.MainMenu
{
    public sealed class MainMenuViewModel : IMainMenuViewModel
    {
        private readonly IBoardModel _boardModel;
        private readonly ICommandDispatcher _commandDispatcher;

        public MainMenuViewModel(IBoardModel boardModel, ICommandDispatcher commandDispatcher)
        {
            _boardModel = boardModel;
            _commandDispatcher = commandDispatcher;
        }

        public void OnStart(
            int size = 5,
            int quizTilesPercentage = 30,
            BoardPatternType patternType = BoardPatternType.Circular)
        {
            if (size > 0)
                _boardModel.Size = size;
            if (quizTilesPercentage > 0)
                _boardModel.QuizTilesPercentage = quizTilesPercentage;
            _boardModel.PatternType = patternType;

            _commandDispatcher.Execute(new LoadSceneCommand(SceneType.Board));
        }
    }
}