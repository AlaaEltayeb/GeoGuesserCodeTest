using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BoardGeneration
{
    public interface IBoardModel
    {
        const float TileSize = 0.5f;

        GameObject TilePrefab { get; }

        int Size { get; set; }
        float QuizTilesPercentage { get; set; }
        BoardPatternType PatternType { get; set; }

        public List<ITile> Tiles { get; set; }
    }
}