using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.BoardGeneration
{
    public sealed class BoardView : MonoBehaviour
    {
        private IBoardGenerator _generator;

        [SerializeField]
        private TileView _tilePrefab;

        [SerializeField]
        private int _radius = 5;
        [SerializeField]
        private float _tileSize = 0.5f;
        [SerializeField]
        private float _quizTilesPercentage = 30;
        [SerializeField]
        private BoardPatternType _patternType = BoardPatternType.Circular;

        private BoardModel _boardModel;

        [Inject]
        private void Constructor(BoardModel boardModel)
        {
            _boardModel = boardModel;
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            _generator = new BoardGenerator(
                _radius,
                _tileSize,
                _quizTilesPercentage,
                _patternType);

            _boardModel.Tiles = _generator.GenerateTiles();
            foreach (var tile in _boardModel.Tiles)
            {
                var tileView = Instantiate(
                    _tilePrefab,
                    tile.Position,
                    Quaternion.identity,
                    transform);

                tileView.transform.localScale = tile.LocalScale;
                tileView.SetupTile(tile);
            }
        }
    }
}