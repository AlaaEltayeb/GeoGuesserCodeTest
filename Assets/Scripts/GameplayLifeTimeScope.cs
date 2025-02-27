using Assets.Scripts.Player;
using Assets.Scripts.UI;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts
{
    public sealed class GameplayLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IPlayerController, PlayerController>(Lifetime.Singleton);
            builder.Register<IMiniGameManager, MiniGameManager>(Lifetime.Singleton);
            builder.Register<IPlayerState, PlayerState>(Lifetime.Singleton);
            builder.Register<IMiniGameModel, MiniGamesModel>(Lifetime.Singleton);
        }
    }
}