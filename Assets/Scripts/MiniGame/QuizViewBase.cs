using Assets.Scripts.Command;
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
        protected GameObject Panel { get; private set; }

        protected const int Score = 500;

        protected int CorrectAnswerIndex { get; set; }
        protected QuizData QuizData { get; set; }

        protected IMiniGameModel MiniGameModel { get; private set; }
        protected ICommandDispatcher CommandDispatcher { get; private set; }

        [Inject]
        private void Constructor(IMiniGameModel miniGameModel, ICommandDispatcher commandDispatcher)
        {
            MiniGameModel = miniGameModel;
            CommandDispatcher = commandDispatcher;
        }

        public abstract void Populate();

        public virtual void SelectAnswer(int answer)
        {
            if (CorrectAnswerIndex == answer)
                Debug.Log("Good Job");

            Panel.SetActive(false);
            CommandDispatcher.Execute(new ShowMiniGameResultCommand(
                Score,
                QuizData,
                CorrectAnswerIndex == answer));
        }
    }
}