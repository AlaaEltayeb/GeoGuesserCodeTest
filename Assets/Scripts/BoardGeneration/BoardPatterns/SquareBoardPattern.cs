using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Extensions;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BoardGeneration.BoardPatterns
{
    public sealed class SquarePattern : BoardPatternBase
    {
        public SquarePattern(int radius, float tileSize) : base(radius, tileSize)
        {
        }

        public override List<TileData> GenerateTilesData()
        {
            var tilesData = new List<TileData>();
            var tilesPositions = new List<Vector2Int>();

            for (var x = 0; x < Radius; x++)
            {
                for (var z = 0; z < Radius; z++)
                {
                    if (x != 0 && x != Radius - 1 && z != 0 && z != Radius - 1)
                        continue;

                    tilesPositions.Add(new Vector2Int(x, z));
                }
            }

            tilesPositions = tilesPositions.OrderByClosestNeighbor();

            foreach (var tilesPosition in tilesPositions)
            {
                var spawnPosition = new Vector3(tilesPosition.x * TileSize, 0, tilesPosition.y * TileSize);

                var tileData = new TileData(
                    spawnPosition,
                    Vector3.one);
                tilesData.Add(tileData);
            }

            return tilesData;
        }
    }
}