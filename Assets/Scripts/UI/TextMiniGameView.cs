using Assets.Scripts.Extensions;
using Assets.Scripts.Quiz;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;
using VContainer;

namespace Assets.Scripts.UI
{
    public sealed class TextMiniGameView : MonoBehaviour
    {
        [SerializeField]
        private List<TextMeshProUGUI> _answers;
        [SerializeField]
        private Image _place;
        [SerializeField]
        private TextMeshProUGUI _question;

        [SerializeField]
        private GameObject _result;

        private int _correctAnswerIndex;

        private QuizData _quizData;

        private IMiniGameModel _miniGameModel;

        [Inject]
        private void Constructor(IMiniGameModel miniGameModel)
        {
            _miniGameModel = miniGameModel;
        }

        private void OnEnable()
        {
            var selectedQuiz = Random.Range(0, _miniGameModel.TextQuizzes.Count);
            _quizData = _miniGameModel.TextQuizzes[selectedQuiz];

            Populate();
        }

        private void Populate()
        {
            var answers = _quizData.Answers.Select(answer => answer.Text).ToList();
            var correctAnswer = answers[_quizData.CorrectAnswerIndex];
            answers.Shuffle();
            _correctAnswerIndex = answers.IndexOf(correctAnswer);

            for (var i = 0; i < answers.Count; i++)
            {
                _answers[i].text = answers[i];
            }

            _question.text = _quizData.Question;
            Addressables
                .LoadAssetAsync<Sprite>(_quizData.CustomImageID)
                .Completed += OnIconLoaded;
        }

        private void OnIconLoaded(AsyncOperationHandle<Sprite> handle)
        {
            _place.sprite = handle.Result;
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