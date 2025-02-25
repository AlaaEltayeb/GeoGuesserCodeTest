using Assets.Scripts.BoardGeneration;
using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class GameManager : MonoBehaviour
    {
        private IBoardGenerator _generator;
        [SerializeField]
        private Transform _playerController;

        [SerializeField]
        private int _radius = 5;
        [SerializeField]
        private float _tileSize = 0.5f;
        [SerializeField]
        private float _quizTilesPercentage = 30;

        [SerializeField]
        private TileView _tilePrefab;

        [SerializeField]
        private BoardPatternType _patternType;

        private int _playerCurrentPositionIndex;
        private int _playerTargetPositionIndex;
        private List<ITile> _tiles;

        private float _jumpCooldown = 1;
        private float _timer = 1;

        private const int MinDiceCount = 1;
        private const int MaxDiceCount = 7;

        public void GenerateBoard()
        {
            _generator = new BoardGenerator(
                _radius,
                _tileSize,
                _quizTilesPercentage,
                _patternType);

            _tiles = _generator.GenerateTiles();
            foreach (var tile in _tiles)
            {
                var tileView = Instantiate(_tilePrefab, tile.Position, Quaternion.identity, transform);
                tileView.transform.localScale = tile.LocalScale;
                tileView.SetupTile(tile);
            }

            _playerController.position = _tiles[_playerCurrentPositionIndex].Position;
        }

        public void MovePlayer()
        {
            var jumpsCount = Random.Range(MinDiceCount, MaxDiceCount);
            _playerTargetPositionIndex = _playerCurrentPositionIndex;
            _playerTargetPositionIndex += jumpsCount;
        }

        private void Update()
        {
            if (_playerCurrentPositionIndex >= _playerTargetPositionIndex)
                return;

            _timer += Time.deltaTime;
            if (_timer < _jumpCooldown)
                return;

            _playerCurrentPositionIndex++;
            if (_playerCurrentPositionIndex >= _tiles.Count)
            {
                _playerCurrentPositionIndex = 0;
                _playerTargetPositionIndex -= _tiles.Count;
            }

            _playerController.position = _tiles[_playerCurrentPositionIndex].Position;
            _timer = 0;
        }
    }
}