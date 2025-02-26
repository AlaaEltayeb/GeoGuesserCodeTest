using System;

namespace Assets.Scripts.Player
{
    public sealed class PlayerController : IPlayerController
    {
        public Action<int> OnPlayerMove { get; set; }

        public void MovePlayer(int steps)
        {
            OnPlayerMove?.Invoke(steps);
        }
    }
}