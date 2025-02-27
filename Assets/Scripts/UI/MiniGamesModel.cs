using Assets.Scripts.Quiz;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public sealed class MiniGamesModel : IMiniGameModel
    {
        public List<QuizData> FlagsQuizzes { get; set; }
        public List<QuizData> TextQuizzes { get; set; }

        public void GenerateQuizzes(List<TextAsset> textAssets)
        {
            var quizzesData = new List<QuizData>();
            foreach (var quizTextAsset in textAssets)
            {
                var quizData = JsonUtility.FromJson<QuizData>(quizTextAsset.ToString());
                quizzesData.Add(quizData);
            }

            TextQuizzes = quizzesData.Where(quizData => quizData.QuestionType == (int)QuizType.Text).ToList();
            FlagsQuizzes = quizzesData.Where(quizData => quizData.QuestionType == (int)QuizType.Flags).ToList();
        }
    }
}