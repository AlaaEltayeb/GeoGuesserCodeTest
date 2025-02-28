using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.BoardGeneration.Tiles;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.BoardGeneration
{
    public sealed class BoardModel : IBoardModel
    {
        private const string TilePrefabName = "Tile";

        public GameObject TilePrefab { get; private set; }

        public int Size { get; set; } = 5;
        public float QuizTilesPercentage { get; set; } = 30;
        public BoardPatternType PatternType { get; set; } = BoardPatternType.Circular;

        public List<ITile> Tiles { get; set; } = new();

        public BoardModel()
        {
            Addressables
                .LoadAssetAsync<GameObject>(TilePrefabName)
                .Completed += OnPrefabLoaded;
        }

        private void OnPrefabLoaded(AsyncOperationHandle<GameObject> handle)
        {
            TilePrefab = handle.Result;
            Addressables.Release(handle);
        }
    }
}