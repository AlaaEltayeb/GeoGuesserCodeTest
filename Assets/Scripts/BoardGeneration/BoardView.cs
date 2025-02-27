using Assets.Scripts.BoardGeneration.Tiles;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.BoardGeneration
{
    public sealed class BoardView : MonoBehaviour
    {
        private IBoardModel _boardModel;
        private IBoardGenerator _generator;

        [Inject]
        private void Constructor(IBoardModel boardModel)
        {
            _boardModel = boardModel;
            GenerateBoard();
        }

        private void GenerateBoard()
        {
            _generator = new BoardGenerator(
                _boardModel.Size,
                IBoardModel.TileSize,
                _boardModel.QuizTilesPercentage,
                _boardModel.PatternType);

            _boardModel.Tiles = _generator.GenerateTiles();

            foreach (var tile in _boardModel.Tiles)
            {
                var tileView = Instantiate(
                    _boardModel.TilePrefab,
                    tile.TileData.Position,
                    Quaternion.identity,
                    transform);

                tileView.transform.localScale = tile.TileData.LocalScale;
                tileView.GetComponent<TileView>().SetupTile(tile);
            }
        }
    }
}