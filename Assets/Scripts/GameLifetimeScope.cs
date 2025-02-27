using Assets.Scripts.BoardGeneration;
using Assets.Scripts.Command;
using VContainer;
using VContainer.Unity;

namespace Assets.Scripts
{
    public class GameLifetimeScope : LifetimeScope
    {
        protected override void Configure(IContainerBuilder builder)
        {
            builder.Register<IBoardModel, BoardModel>(Lifetime.Singleton);
            builder.Register<ICommandFactory, CommandFactory>(Lifetime.Singleton);
            builder.Register<ICommandDispatcher, CommandDispatcher>(Lifetime.Singleton);

            DontDestroyOnLoad(gameObject);
        }
    }
}