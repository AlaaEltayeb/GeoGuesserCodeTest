using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.BoardGeneration.BoardPatterns
{
    public sealed class HexagonalBoardPattern : BoardPatternBase
    {
        public HexagonalBoardPattern(int radius, float tileSize) : base(radius, tileSize)
        {
        }

        public override List<TileData> GenerateTilesData()
        {
            var hexPositions = new List<Vector2Int>();

            for (var x = -Radius; x <= Radius; x++)
            {
                for (var z = Mathf.Max(-Radius, -x - Radius); z <= Mathf.Min(Radius, -x + Radius); z++)
                {
                    var y = -x - z;

                    if (Mathf.Abs(x) < Radius && Mathf.Abs(z) < Radius && Mathf.Abs(y) < Radius)
                        continue;

                    hexPositions.Add(new Vector2Int(x, z));
                }
            }

            return hexPositions
                .OrderByClosestNeighbor()
                .Select(pos => HexCoordinateToWorld(pos.x, pos.y))
                .Select(worldPos => new TileData(worldPos, Vector3.one))
                .ToList();
        }

        private Vector3 HexCoordinateToWorld(int x, int z)
        {
            var worldX = TileSize / 2 * Mathf.Sqrt(3) * (x + z * 0.5f);
            var worldZ = TileSize / 2 * 1.5f * z;
            return new Vector3(worldX, 0, worldZ);
        }
    }
}