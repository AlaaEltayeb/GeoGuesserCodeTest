using Assets.Scripts.BoardGeneration;
using Assets.Scripts.Command;
using Assets.Scripts.MiniGame;
using Assets.Scripts.Player;
using Assets.Scripts.Score;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Awake()
        {
            base.Awake();
            DontDestroyOnLoad(gameObject);
        }

        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IBoardModel, BoardModel>(Lifetime.Singleton);

            builder.Register<ICommandFactory, CommandFactory>(Lifetime.Singleton);
            builder.Register<ICommandDispatcher, CommandDispatcher>(Lifetime.Singleton);

            builder.Register<IPlayerViewModel, PlayerViewModel>(Lifetime.Singleton);
            builder.Register<IPlayerState, PlayerState>(Lifetime.Singleton);

            builder.Register<IMiniGameModel, MiniGamesModel>(Lifetime.Singleton);
            builder.Register<IMiniGameViewModel, MiniGameViewModel>(Lifetime.Singleton);

            builder.Register<IScoreModel, ScoreModel>(Lifetime.Singleton);
            builder.Register<IFloatingScoreViewModel, FloatingScoreViewModel>(Lifetime.Singleton);
        }
    }
}