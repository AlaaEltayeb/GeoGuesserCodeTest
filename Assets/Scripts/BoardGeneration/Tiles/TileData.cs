using UnityEngine;

namespace Assets.Scripts.BoardGeneration.Tiles
{
    public struct TileData
    {
        public Vector3 Position { get; private set; }
        public Vector3 LocalScale { get; private set; }

        public TileData(Vector3 position, Vector3 localScale)
        {
            Position = position;
            LocalScale = localScale;
        }
    }
}