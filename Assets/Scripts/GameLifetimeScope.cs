using Assets.Scripts.BoardGeneration;
using Assets.Scripts.Command;
using Assets.Scripts.Player;
using Assets.Scripts.UI;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts
{
    public sealed class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IPlayerController, PlayerController>(Lifetime.Singleton);
            builder.Register<IMiniGameManager, MiniGameManager>(Lifetime.Singleton);
            builder.Register<ICommandDispatcher, CommandDispatcher>(Lifetime.Singleton);
            builder.Register<ICommandFactory, CommandFactory>(Lifetime.Singleton);
            builder.Register<IPlayerState, PlayerState>(Lifetime.Singleton);
            builder.Register<BoardModel>(Lifetime.Singleton);

            //builder.Register<IFlagsMiniGameController, IFlagsMiniGameController>(Lifetime.Singleton);
        }
    }
}