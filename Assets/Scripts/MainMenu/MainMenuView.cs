using Assets.Scripts.BoardGeneration;
using Assets.Scripts.BoardGeneration.BoardPatterns;
using Assets.Scripts.Command;
using Assets.Scripts.SceneLoading;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Assets.Scripts.MainMenu
{
    public sealed class MainMenuView : MonoBehaviour
    {
        [SerializeField]
        private TMP_InputField _sizeInputField;
        [SerializeField]
        private TMP_InputField _quizTilesPercentageInputField;
        [SerializeField]
        private TMP_Dropdown _boardPatternDropDown;
        [SerializeField]
        private Button _startButton;

        private IBoardModel _boardModel;
        private ICommandDispatcher _commandDispatcher;

        [Inject]
        private void Constructor(IBoardModel boardModel, ICommandDispatcher commandDispatcher)
        {
            _boardModel = boardModel;
            _commandDispatcher = commandDispatcher;
        }

        private void Start()
        {
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            if (int.TryParse(_sizeInputField.text, out var size))
                _boardModel.Size = size;

            if (int.TryParse(_quizTilesPercentageInputField.text, out var quizTilesPercentage))
                _boardModel.QuizTilesPercentage = quizTilesPercentage;

            _boardModel.PatternType = (BoardPatternType)_boardPatternDropDown.value;

            _commandDispatcher.Execute(new LoadSceneCommand(SceneType.Board));
        }
    }
}