using Assets.Scripts.Command;
using UnityEngine.AddressableAssets;

namespace Assets.Scripts.SceneLoading
{
    public sealed class LoadSceneCommand : ICommand
    {
        private readonly SceneType _sceneToLoad;

        public LoadSceneCommand(SceneType sceneToLoad)
        {
            _sceneToLoad = sceneToLoad;
        }

        public void Execute()
        {
            Addressables.LoadSceneAsync(_sceneToLoad.ToString());
        }
    }
}