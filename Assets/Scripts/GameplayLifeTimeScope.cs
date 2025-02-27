using Assets.Scripts.DiceController;
using Assets.Scripts.Player;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts
{
    public sealed class GameplayLifeTimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IDiceViewModel, DiceViewModel>(Lifetime.Singleton);
            builder.Register<IPlayerState, PlayerState>(Lifetime.Singleton);
        }
    }
}