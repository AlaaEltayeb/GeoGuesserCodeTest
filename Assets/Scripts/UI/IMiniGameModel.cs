using Assets.Scripts.Quiz;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public interface IMiniGameModel
    {
        List<QuizData> FlagsQuizzes { get; set; }
        List<QuizData> TextQuizzes { get; set; }
    }
}