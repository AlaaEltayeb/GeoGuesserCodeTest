using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts.Extensions
{
    public static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> list)
        {
            var n = list.Count;
            var random = new Random();

            while (n > 1)
            {
                n--;
                var k = random.Next(n + 1);
                (list[k], list[n]) = (list[n], list[k]);
            }
        }

        public static List<Vector2Int> OrderByClosestNeighbor(this List<Vector2Int> hexPositions)
        {
            if (hexPositions.Count == 0)
                return new List<Vector2Int>();

            var orderedPositions = new List<Vector2Int>();
            orderedPositions.Add(hexPositions[0]);
            hexPositions.RemoveAt(0);

            while (hexPositions.Count > 0)
            {
                var lastTile = orderedPositions.Last();

                var closestTile = hexPositions
                    .OrderBy(pos => Vector2Int.Distance(lastTile, pos))
                    .First();

                orderedPositions.Add(closestTile);
                hexPositions.Remove(closestTile);
            }

            hexPositions = orderedPositions;
            return hexPositions;
        }
    }
}