using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Command;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.BoardGeneration
{
    public sealed class BoardManager : MonoBehaviour
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

        private ICommandDispatcher _commandDispatcher;
        private BoardModel _boardModel;

        [Inject]
        private void Constructor(BoardModel boardModel, ICommandDispatcher commandDispatcher)
        {
            _boardModel = boardModel;
            _commandDispatcher = commandDispatcher;
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
                var tileView = Instantiate(_tilePrefab, tile.Position, Quaternion.identity);
                tileView.transform.localScale = tile.LocalScale;
                tileView.SetupTile(tile);
            }

            _commandDispatcher.Execute(
                new SetInitialPlayerPositionCommand(_boardModel.Tiles[0].Position));
        }
    }
}