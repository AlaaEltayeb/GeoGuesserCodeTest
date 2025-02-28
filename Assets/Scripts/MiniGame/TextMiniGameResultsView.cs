using Assets.Scripts.Quiz;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Assets.Scripts.MiniGame
{
    public sealed class TextMiniGameResultsView : QuizResultViewBase
    {
        public override void Populate(int score, QuizData quizData, bool succeeded)
        {
            ResultText.text = succeeded ? SucceedMessage : FailedMessage;
            CorrectAnswerText.text = quizData.Answers[quizData.CorrectAnswerIndex].Text;
            ScoreText.text = succeeded ? score.ToString() : "0";

            Addressables
                .LoadAssetAsync<Sprite>(quizData.CustomImageID)
                .Completed += OnIconLoaded;
        }

        private void OnIconLoaded(AsyncOperationHandle<Sprite> handle)
        {
            QuestionImage.sprite = handle.Result;
            Panel.SetActive(true);
            Addressables.Release(handle);
        }
    }
}