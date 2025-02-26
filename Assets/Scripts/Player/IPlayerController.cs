using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public interface IPlayerController
    {
        Action<int> OnPlayerMove { get; set; }
        Action<Vector3> OnPlayerInitialize { get; set; }

        void SetInitialPosition(Vector3 position);
        void MovePlayer(int steps);
    }
}