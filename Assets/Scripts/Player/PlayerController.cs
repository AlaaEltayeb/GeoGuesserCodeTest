using System;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public sealed class PlayerController : IPlayerController
    {
        public Action<int> OnPlayerMove { get; set; }
        public Action<Vector3> OnPlayerInitialize { get; set; }

        public void SetInitialPosition(Vector3 position)
        {
            OnPlayerInitialize?.Invoke(position);
        }

        public void MovePlayer(int steps)
        {
            OnPlayerMove?.Invoke(steps);
        }
    }
}