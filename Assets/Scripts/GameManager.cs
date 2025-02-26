using Assets.Scripts.BoardGeneration;
using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using Assets.Scripts.Command;
using Assets.Scripts.Quiz;
using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;
using VContainer;

namespace Assets.Scripts
{
    public sealed class GameManager : MonoBehaviour
    {
        private IBoardGenerator _generator;

        [SerializeField]
        private Transform _playerController;
        [SerializeField]
        private Animator _playerAnimator;
        [SerializeField]
        private ParticleSystem _particleSystem;
        [SerializeField]
        private Animator _floatingTextAnimator;

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

        private float _moveCooldown = 1;

        private const int MinDiceCount = 1;
        private const int MaxDiceCount = 7;

        private bool _isMoving;

        [SerializeField]
        private List<TextAsset> _quizTextAssets;
        public List<QuizData> QuizDatas;

        private ICommandDispatcher _commandDispatcher;

        [Inject]
        private void Constructor(ICommandDispatcher commandDispatcher)
        {
            _commandDispatcher = commandDispatcher;
        }

        private void Start()
        {
            foreach (var quizTextAsset in _quizTextAssets)
            {
                var quizData = JsonUtility.FromJson<QuizData>(quizTextAsset.ToString());
                QuizDatas.Add(quizData);
            }
        }

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

            _commandDispatcher.Execute(
                new SetInitialPlayerPositionCommand(_tiles[_playerCurrentPositionIndex].Position));
            //_playerController.position = _tiles[_playerCurrentPositionIndex].Position;
        }

        public void PrepareMove()
        {
            if (_isMoving)
                return;

            var stepsCount = Random.Range(MinDiceCount, MaxDiceCount);
            _commandDispatcher.Execute(new MoveCommand(stepsCount, _tiles));
            Debug.Log(stepsCount);
            _playerTargetPositionIndex = _playerCurrentPositionIndex;
            _playerTargetPositionIndex += stepsCount;

            _isMoving = true;
            MovePlayer();
        }

        private void MovePlayer()
        {
            if (_playerCurrentPositionIndex >= _playerTargetPositionIndex)
            {
                _isMoving = false;
                return;
            }

            if (_tiles[_playerCurrentPositionIndex] is EmptyTile)
            {
                _particleSystem.Play();
                _floatingTextAnimator.SetTrigger("Play");
            }

            _playerCurrentPositionIndex++;
            if (_playerCurrentPositionIndex >= _tiles.Count)
            {
                _playerCurrentPositionIndex = 0;
                _playerTargetPositionIndex -= _tiles.Count;
            }

            _playerAnimator.SetTrigger("Jump");

            var target = _tiles[_playerCurrentPositionIndex].Position;
            _playerController
                .DOMove(target, _moveCooldown)
                .SetEase(Ease.InOutSine)
                .onComplete = MovePlayer;
        }
    }
}