using System;

namespace Assets.Scripts.UI
{
    public interface IMiniGameManager
    {
        Action<int> OnShowMiniGame { get; set; }
        void ShowMiniGame();
    }
}