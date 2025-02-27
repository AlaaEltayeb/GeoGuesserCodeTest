using Assets.Scripts.Quiz;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.UI
{
    public interface IMiniGameModel
    {
        List<QuizData> FlagsQuizzes { get; set; }
        List<QuizData> TextQuizzes { get; set; }

        void GenerateQuizzes(List<TextAsset> textAssets);
    }
}