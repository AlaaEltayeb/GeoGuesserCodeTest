using UnityEngine;

namespace Assets.Scripts.BoardGeneration.Tiles
{
    public abstract class TileBase : ITile
    {
        public Vector3 Position { get; private set; }
        public Vector3 LocalScale { get; private set; }

        public virtual void SetTileData(Vector3 position, Vector3 localScale)
        {
            Position = position;
            LocalScale = localScale;
        }
    }
}