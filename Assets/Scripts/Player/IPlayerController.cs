using System;

namespace Assets.Scripts.Player
{
    public interface IPlayerController
    {
        Action<int> OnPlayerMove { get; set; }

        void MovePlayer(int steps);
    }
}