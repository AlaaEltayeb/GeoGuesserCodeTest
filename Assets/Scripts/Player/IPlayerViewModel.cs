using Assets.Scripts.BoardGeneration.Tiles;
using System;
using System.Collections.Generic;

namespace Assets.Scripts.Player
{
    public interface IPlayerViewModel
    {
        public List<ITile> Tiles { get; }
        Action<int> OnPlayerMove { get; set; }

        void MovePlayer(int steps);
        void OnMovementEnded(bool shouldShowQuiz);
    }
}