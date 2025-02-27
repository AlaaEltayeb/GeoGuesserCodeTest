using Assets.Scripts.Extensions;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.UI;

namespace Assets.Scripts.MiniGame
{
    public sealed class FlagsQuizView : QuizViewBase
    {
        [SerializeField]
        private List<Image> _flags;

        private const string AssetLabel = "Flags";

        public override void Populate()
        {
            var selectedQuiz = Random.Range(0, MiniGameModel.FlagsQuizzes.Count);
            QuizData = MiniGameModel.FlagsQuizzes[selectedQuiz];

            Addressables.LoadResourceLocationsAsync(AssetLabel, typeof(Sprite)).Completed
                += OnResourceLocationsLoaded;
        }

        private void OnResourceLocationsLoaded(AsyncOperationHandle<IList<IResourceLocation>> handle)
        {
            Addressables
                .LoadAssetsAsync<Sprite>(
                    handle.Result,
                    null)
                .Completed += OnFlagSpriteLoaded;

            Addressables.Release(handle);
        }

        private void OnFlagSpriteLoaded(AsyncOperationHandle<IList<Sprite>> handle)
        {
            var flags = QuizData.Answers.Select(answer => answer.ImageID).ToList();
            var correctAnswer = flags[QuizData.CorrectAnswerIndex];

            var sprites = handle.Result.ToList();
            sprites.Shuffle();

            var sprite = sprites.FirstOrDefault(sprite => sprite.name == correctAnswer);
            CorrectAnswerIndex = sprites.IndexOf(sprite);

            for (var i = 0; i < sprites.Count; i++)
            {
                _flags[i].sprite = sprites[i];
            }

            Question.text = QuizData.Question;

            Panel.SetActive(true);
            Addressables.Release(handle);
        }
    }
}