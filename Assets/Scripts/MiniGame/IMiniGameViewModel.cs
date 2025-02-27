using System;

namespace Assets.Scripts.MiniGame
{
    public interface IMiniGameViewModel
    {
        Action<int> OnShowMiniGame { get; set; }

        void ShowMiniGame();
    }
}