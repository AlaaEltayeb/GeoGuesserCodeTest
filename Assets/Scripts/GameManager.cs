using Assets.Scripts.Quiz;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts
{
    public sealed class GameManager : MonoBehaviour
    {
        [SerializeField]
        private List<TextAsset> _quizTextAssets;
        public List<QuizData> QuizDatas;

        private void Start()
        {
            foreach (var quizTextAsset in _quizTextAssets)
            {
                var quizData = JsonUtility.FromJson<QuizData>(quizTextAsset.ToString());
                QuizDatas.Add(quizData);
            }
        }
    }
}