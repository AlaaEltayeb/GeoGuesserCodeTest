using Assets.Scripts.Quiz;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.UI
{
    public sealed class MiniGamesModel : IMiniGameModel
    {
        private const string FlagsQuizName = "FlagQuizData";
        private const string CitiesQuizName = "TextQuizData";

        public List<QuizData> FlagsQuizzes { get; set; } = new();
        public List<QuizData> TextQuizzes { get; set; } = new();

        public MiniGamesModel()
        {
            LoadQuizzes();
        }

        private void LoadQuizzes()
        {
            Addressables
                .LoadAssetAsync<TextAsset>(FlagsQuizName)
                .Completed += OnFlagsTextAssetLoaded;
            Addressables
                .LoadAssetAsync<TextAsset>(CitiesQuizName)
                .Completed += OnCitiesTextAssetLoaded;
        }

        private void OnCitiesTextAssetLoaded(AsyncOperationHandle<TextAsset> handle)
        {
            var data = JsonUtility.FromJson<QuizData>(handle.Result.text);
            TextQuizzes.Add(data);
        }

        private void OnFlagsTextAssetLoaded(AsyncOperationHandle<TextAsset> handle)
        {
            var data = JsonUtility.FromJson<QuizData>(handle.Result.text);
            FlagsQuizzes.Add(data);
        }
    }
}