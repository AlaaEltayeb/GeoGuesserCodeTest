using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Extensions;
using System.Collections.Generic;

namespace Assets.Scripts.BoardGeneration
{
    public sealed class BoardGenerator : IBoardGenerator
    {
        private readonly int _radius;
        private readonly float _tileSize;

        private readonly float _quizTilesPercentage;
        private readonly BoardPatternType _patternType;

        private IBoardPattern _boardPattern;

        public BoardGenerator(
            int radius,
            float tileSize,
            float quizTilesPercentage,
            BoardPatternType patternType)
        {
            _radius = radius;
            _tileSize = tileSize;
            _quizTilesPercentage = quizTilesPercentage;
            _patternType = patternType;
            SetPattern();
        }

        public void SetPattern()
        {
            _boardPattern = _patternType switch
            {
                BoardPatternType.Circular => new CircularBoardPattern(_radius, _tileSize),
                BoardPatternType.Hexagonal => new HexagonalBoardPattern(_radius, _tileSize),
                BoardPatternType.Square => new SquarePattern(_radius, _tileSize),
                _ => new CircularBoardPattern(_radius, _tileSize),
            };
        }

        public List<ITile> GenerateTiles()
        {
            var tiles = new List<ITile>();
            var patternData = _boardPattern.GeneratePatternData();

            var tilesCount = patternData.Count;

            var quizTilesCount = 0;
            var quizTilesMaxCount = tilesCount * (_quizTilesPercentage / 100);

            for (var i = 1; i < tilesCount; i++)
            {
                if (quizTilesCount < quizTilesMaxCount)
                {
                    var quizTile = new QuizTile();
                    tiles.Add(quizTile);
                    quizTilesCount++;
                    continue;
                }

                var emptyTile = new EmptyTile();
                tiles.Add(emptyTile);
            }

            tiles.Shuffle();
            var firstTile = new EmptyTile();
            tiles.Insert(0, firstTile);

            for (var i = 0; i < tiles.Count; i++)
            {
                tiles[i]
                    .SetTileData(
                        patternData[i].Position,
                        patternData[i].LocalScale);
            }

            return tiles;
        }
    }
}