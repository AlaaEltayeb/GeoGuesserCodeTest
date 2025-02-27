using Assets.Scripts.Quiz;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.MiniGame
{
    public sealed class FlagsMiniGameResultsView : QuizResultViewBase
    {
        public override void Populate(int score, QuizData quizData, bool succeeded)
        {
            ResultText.text = succeeded ? SucceedMessage : FailedMessage;
            CorrectAnswerText.text = quizData.Question;
            ScoreText.text = score.ToString();
            ScoreText.text = succeeded ? score.ToString() : "0";

            var imageId = quizData.Answers[quizData.CorrectAnswerIndex].ImageID;
            Addressables
                .LoadAssetAsync<Sprite>(imageId)
                .Completed += OnIconLoaded;
        }

        private void OnIconLoaded(AsyncOperationHandle<Sprite> handle)
        {
            QuestionImage.sprite = handle.Result;
            Addressables.Release(handle);
        }
    }
}