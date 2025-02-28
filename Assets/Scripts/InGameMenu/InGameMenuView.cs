using Assets.Scripts.Command;
using Assets.Scripts.SceneLoading;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.InGameMenu
{
    public sealed class InGameMenuView : MonoBehaviour
    {
        private ICommandDispatcher _commandDispatcher;

        [Inject]
        private void Constructor(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        public void GoToMainMenu()
        {
            _commandDispatcher.Execute(new LoadSceneCommand(SceneType.MainMenu));
        }
    }
}