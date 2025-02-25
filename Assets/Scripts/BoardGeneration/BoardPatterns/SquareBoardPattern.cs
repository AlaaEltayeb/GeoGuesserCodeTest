using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BoardGeneration.BoardPatterns
{
    public sealed class SquarePattern : BoardPatternBase
    {
        public SquarePattern(int radius, float tileSize) : base(radius, tileSize)
        {
        }

        public override List<TileData> GeneratePatternData()
        {
            var tilesData = new List<TileData>();
            for (var x = 0; x < Radius; x++)
            {
                for (var z = 0; z < Radius; z++)
                {
                    if (x != 0 && x != Radius - 1 && z != 0 && z != Radius - 1)
                        continue;

                    var spawnPosition = new Vector3(x * TileSize, 0, z * TileSize);

                    var tileData = new TileData(
                        spawnPosition,
                        Vector3.one);
                    tilesData.Add(tileData);
                }
            }

            return tilesData;
        }
    }
}