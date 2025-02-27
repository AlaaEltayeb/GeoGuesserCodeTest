using Assets.Scripts.Quiz;
using TMPro;
using UnityEngine;
using VContainer;

namespace Assets.Scripts.MiniGame
{
    public abstract class QuizViewBase : MonoBehaviour
    {
        [field: SerializeField]
        protected TextMeshProUGUI Question { get; private set; }

        [field: SerializeField]
        public QuizType QuizType { get; private set; }

        [field: SerializeField]
        protected GameObject Result { get; private set; }

        [field: SerializeField]
        protected GameObject Panel { get; private set; }

        protected int CorrectAnswerIndex { get; set; }
        protected QuizData QuizData { get; set; }

        protected IMiniGameModel MiniGameModel { get; private set; }

        [Inject]
        private void Constructor(IMiniGameModel miniGameModel)
        {
            MiniGameModel = miniGameModel;
        }

        public abstract void Populate();
    }
}