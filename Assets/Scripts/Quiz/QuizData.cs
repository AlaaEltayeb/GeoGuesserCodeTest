using System;
using System.Collections.Generic;

namespace Assets.Scripts.Quiz
{
    [Serializable]
    public struct QuizData
    {
        public string ID;
        public string QuestionType;
        public string Question;
        public string CustomImageID;
        public List<Answer> Answers;
        public int CorrectAnswerIndex;
    }
}