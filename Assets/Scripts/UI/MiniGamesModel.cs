using Assets.Scripts.Quiz;
using System.Collections.Generic;

namespace Assets.Scripts.UI
{
    public sealed class MiniGamesModel : IMiniGameModel
    {
        public List<QuizData> FlagsQuizzes { get; set; }
        public List<QuizData> TextQuizzes { get; set; }
    }
}