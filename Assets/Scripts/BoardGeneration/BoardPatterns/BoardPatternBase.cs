using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;

namespace Assets.Scripts.BoardGeneration.BoardPatterns
{
    public abstract class BoardPatternBase : IBoardPattern
    {
        public int Radius { get; private set; }
        public float TileSize { get; private set; }

        protected BoardPatternBase(int radius, float tileSize)
        {
            Radius = radius;
            TileSize = tileSize;
        }

        public abstract List<TileData> GeneratePatternData();
    }
}