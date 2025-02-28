using Assets.Scripts.Command;
using Assets.Scripts.Player;
using Assets.Scripts.Score;
using VContainer;

namespace Assets.Scripts
{
    public sealed class ResetGameDataCommand : ICommand
    {
        private IPlayerState _playerState;
        private IScoreModel _scoreModel;

        [Inject]
        private void Constructor(IPlayerState playerState, IScoreModel scoreModel)
        {
            _playerState = playerState;
            _scoreModel = scoreModel;
        }

        public void Execute()
        {
            _playerState.IsMoving = false;
            _scoreModel.Score = 0;
        }
    }
}