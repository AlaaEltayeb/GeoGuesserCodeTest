using Assets.Scripts.Command;
using VContainer;

namespace Assets.Scripts.Score
{
    public class ShowFloatingScoreCommand : ICommand
    {
        private IFloatingScoreViewModel _floatingScoreViewModel;

        [Inject]
        private void Constructor(IFloatingScoreViewModel floatingScoreViewModel)
        {
            _floatingScoreViewModel = floatingScoreViewModel;
        }

        public void Execute()
        {
            _floatingScoreViewModel.ShowFloatingScore();
        }
    }
}