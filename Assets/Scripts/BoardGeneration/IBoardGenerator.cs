using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;

namespace Assets.Scripts.BoardGeneration
{
    public interface IBoardGenerator
    {
        List<ITile> GenerateTiles();
    }
}