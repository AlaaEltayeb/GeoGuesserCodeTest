using Assets.Scripts.BoardGeneration.BoardPatterns;
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

        private IMainMenuViewModel _mainMenuViewModel;

        [Inject]
        private void Constructor(IMainMenuViewModel mainMenuViewModel)
        {
            _mainMenuViewModel = mainMenuViewModel;
        }

        private void Start()
        {
            _startButton.onClick.AddListener(StartGame);
        }

        private void StartGame()
        {
            int.TryParse(_sizeInputField.text, out var size);
            int.TryParse(_quizTilesPercentageInputField.text, out var quizTilesPercentage);
            var patternType = (BoardPatternType)_boardPatternDropDown.value;

            _mainMenuViewModel.OnStart(
                size,
                quizTilesPercentage,
                patternType);
        }
    }
}