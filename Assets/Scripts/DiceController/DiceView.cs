using UnityEngine;
using UnityEngine.UI;
using VContainer;

namespace Assets.Scripts.DiceController
{
    public sealed class DiceView : MonoBehaviour
    {
        [SerializeField]
        private int _minDiceCount = 1;
        [SerializeField]
        private int _maxDiceCount = 7;
        [SerializeField]
        private Button _rollDiceButton;

        private IDiceViewModel _diceViewModel;

        [Inject]
        private void Constructor(IDiceViewModel diceViewModel)
        {
            _diceViewModel = diceViewModel;
        }

        private void Start()
        {
            _rollDiceButton.onClick.AddListener(() => _diceViewModel.RollDice(_minDiceCount, _maxDiceCount));
        }
    }
}