using Assets.Scripts.BoardGeneration.Tiles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Player
{
    public sealed class PlayerController : IPlayerController
    {
        public Action<int, List<ITile>> OnPlayerMove { get; set; }
        public Action<Vector3> OnPlayerInitialize { get; set; }

        public void SetInitialPosition(Vector3 position)
        {
            OnPlayerInitialize?.Invoke(position);
        }

        public void MovePlayer(int steps, List<ITile> tiles)
        {
            OnPlayerMove?.Invoke(steps, tiles);
        }
    }
}