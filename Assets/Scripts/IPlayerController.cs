using Assets.Scripts.BoardGeneration.Tiles;
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public interface IPlayerController
    {
        Action<int, List<ITile>> OnPlayerMove { get; set; }
        Action<Vector3> OnPlayerInitialize { get; set; }

        void SetInitialPosition(Vector3 position);
        void MovePlayer(int steps, List<ITile> tiles);
    }
}