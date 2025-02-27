using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;

namespace Assets.Scripts.BoardGeneration.BoardPatterns
{
    public interface IBoardPattern
    {
        int Radius { get; }
        float TileSize { get; }

        List<TileData> GenerateTilesData();
    }
}