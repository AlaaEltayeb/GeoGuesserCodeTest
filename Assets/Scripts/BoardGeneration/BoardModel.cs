using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;

namespace Assets.Scripts.BoardGeneration
{
    public sealed class BoardModel
    {
        public List<ITile> Tiles { get; set; }
    }
}