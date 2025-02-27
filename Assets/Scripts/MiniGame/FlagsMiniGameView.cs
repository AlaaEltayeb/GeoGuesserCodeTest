using Assets.Scripts.Extensions;
using Assets.Scripts.Quiz;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.ResourceManagement.ResourceLocations;
using UnityEngine.UI;
using VContainer;

namespace Assets.Scripts.UI
{
    public sealed class FlagsMiniGameView : MonoBehaviour
    {
        [SerializeField]
        private List<Image> _flags;

        [SerializeField]
        private TextMeshProUGUI _question;

        [SerializeField]
        private GameObject _result;

        private int _correctAnswerIndex;

        private QuizData _quizData;

        private IMiniGameModel _miniGameModel;

        private const string AssetLabel = "Flags";

        [Inject]
        private void Constructor(IMiniGameModel miniGameModel)
        {
            _miniGameModel = miniGameModel;
        }

        private void OnEnable()
        {
            var selectedQuiz = Random.Range(0, _miniGameModel.FlagsQuizzes.Count);
            _quizData = _miniGameModel.FlagsQuizzes[selectedQuiz];

            Populate();
        }

        private void Populate()
        {
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
            var flags = _quizData.Answers.Select(answer => answer.ImageID).ToList();
            var correctAnswer = flags[_quizData.CorrectAnswerIndex];

            var sprites = handle.Result.ToList();
            sprites.Shuffle();

            var sprite = sprites.FirstOrDefault(sprite => sprite.name == correctAnswer);
            _correctAnswerIndex = sprites.IndexOf(sprite);

            for (var i = 0; i < sprites.Count; i++)
            {
                _flags[i].sprite = sprites[i];
            }

            _question.text = _quizData.Question;

            Addressables.Release(handle);
        }

        public void SelectAnswer(int answer)
        {
            if (_correctAnswerIndex == answer)
                Debug.Log("Good Job");

            _result.SetActive(true);
            gameObject.SetActive(false);
        }
    }
}