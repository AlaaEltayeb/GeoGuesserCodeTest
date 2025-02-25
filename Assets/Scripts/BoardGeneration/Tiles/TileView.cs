using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.BoardGeneration.Tiles
{
    public sealed class TileView : MonoBehaviour
    {
        [SerializeField]
        private Material _quizTileMaterial;

        [SerializeField]
        private List<Material> _emptyTileMaterials;

        [SerializeField]
        private MeshRenderer _renderer;

        public ITile Tile { get; private set; }

        public void SetupTile(ITile tile)
        {
            Tile = tile;

            if (tile is QuizTile)
                _renderer.material = _quizTileMaterial;
            else
            {
                var materialIndex = Random.Range(0, _emptyTileMaterials.Count);
                _renderer.material = _emptyTileMaterials[materialIndex];
            }
        }
    }
}