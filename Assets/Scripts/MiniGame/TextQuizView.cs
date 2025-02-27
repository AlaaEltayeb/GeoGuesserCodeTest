using Assets.Scripts.Extensions;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;
using UnityEngine.UI;

namespace Assets.Scripts.MiniGame
{
    public sealed class TextQuizView : QuizViewBase
    {
        [SerializeField]
        private List<TextMeshProUGUI> _answers;
        [SerializeField]
        private Image _place;

        public override void Populate()
        {
            var selectedQuiz = Random.Range(0, MiniGameModel.TextQuizzes.Count);
            QuizData = MiniGameModel.TextQuizzes[selectedQuiz];

            var answers = QuizData.Answers.Select(answer => answer.Text).ToList();
            var correctAnswer = answers[QuizData.CorrectAnswerIndex];
            answers.Shuffle();
            CorrectAnswerIndex = answers.IndexOf(correctAnswer);

            for (var i = 0; i < answers.Count; i++)
            {
                _answers[i].text = answers[i];
            }

            Question.text = QuizData.Question;
            Addressables
                .LoadAssetAsync<Sprite>(QuizData.CustomImageID)
                .Completed += OnIconLoaded;
        }

        private void OnIconLoaded(AsyncOperationHandle<Sprite> handle)
        {
            _place.sprite = handle.Result;
            Panel.SetActive(true);
            Addressables.Release(handle);
        }

        public void SelectAnswer(int answer)
        {
            if (CorrectAnswerIndex == answer)
                Debug.Log("Good Job");

            Panel.SetActive(false);
            Result.SetActive(true);
        }
    }
}