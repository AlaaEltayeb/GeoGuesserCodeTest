using Assets.Scripts.Extensions;
using Assets.Scripts.Quiz;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
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

        private string _correctAnswer;
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
            _quizData = _miniGameModel.FlagsQuizzes[0];
            Populate();
        }

        private void Populate()
        {
            var flags = _quizData.Answers.Select(answer => answer.ImageID).ToList();
            _correctAnswer = flags[_quizData.CorrectAnswerIndex];
            flags.Shuffle();
            _correctAnswerIndex = flags.IndexOf(_correctAnswer);

            for (var i = 0; i < flags.Count; i++)
            {
                _flags[i].sprite = Resources.Load<Sprite>(flags[i]);
            }

            _question.text = _quizData.Question;
        }

        public void SelectAnswer(int answer)
        {
            if (_correctAnswerIndex == answer)
                Debug.Log("Good Job");
        }
    }
}