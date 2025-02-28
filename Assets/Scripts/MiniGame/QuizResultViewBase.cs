using Assets.Scripts.Quiz;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Assets.Scripts.MiniGame
{
    public abstract class QuizResultViewBase : MonoBehaviour
    {
        protected const string SucceedMessage = "Well Done";
        protected const string FailedMessage = "You'll get it right next time!";

        [field: SerializeField]
        public QuizType QuizType { get; private set; }

        [field: SerializeField]
        protected TextMeshProUGUI ResultText { get; private set; }

        [field: SerializeField]
        protected TextMeshProUGUI CorrectAnswerText { get; private set; }

        [field: SerializeField]
        protected TextMeshProUGUI ScoreText { get; private set; }

        [field: SerializeField]
        protected Image QuestionImage { get; private set; }

        [field: SerializeField]
        protected GameObject Panel { get; private set; }

        public abstract void Populate(int score, QuizData quizData, bool succeeded);
    }
}