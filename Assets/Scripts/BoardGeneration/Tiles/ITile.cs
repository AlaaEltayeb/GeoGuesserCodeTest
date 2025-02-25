using UnityEngine;

namespace Assets.Scripts.BoardGeneration.Tiles
{
    public interface ITile
    {
        Vector3 Position { get; }
        Vector3 LocalScale { get; }

        void SetTileData(Vector3 position, Vector3 localScale);
    }
}