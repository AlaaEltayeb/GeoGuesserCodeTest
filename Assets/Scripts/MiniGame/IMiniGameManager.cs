using System;

namespace Assets.Scripts.MiniGame
{
    public interface IMiniGameManager
    {
        Action<int> OnShowMiniGame { get; set; }
        void ShowMiniGame();
    }
}