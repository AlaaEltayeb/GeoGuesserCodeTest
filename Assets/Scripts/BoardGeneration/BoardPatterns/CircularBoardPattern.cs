using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BoardGeneration.BoardPatterns
{
    public sealed class CircularBoardPattern : BoardPatternBase
    {
        public CircularBoardPattern(int radius, float tileSize) : base(radius, tileSize)
        {
        }

        public override List<TileData> GeneratePatternData()
        {
            var tilesData = new List<TileData>();

            var segments = Mathf.RoundToInt(2 * Mathf.PI * Radius / (TileSize / 2));
            var angleStep = 360f / segments;

            for (var i = 0; i < segments; i++)
            {
                var angle = i * angleStep * Mathf.Deg2Rad;

                var x = Mathf.Cos(angle) * Radius;
                var z = Mathf.Sin(angle) * Radius;

                var tileData = new TileData(
                    new Vector3(x, 0, z),
                    new Vector3(TileSize, TileSize, TileSize));
                tilesData.Add(tileData);
            }

            return tilesData;
        }
    }
}