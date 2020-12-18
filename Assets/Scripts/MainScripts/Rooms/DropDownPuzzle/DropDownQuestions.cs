using UnityEngine;
using UnityEngine.UI;
using UPersian.Components;

namespace MainScripts
{
    public class DropDownQuestions : MonoBehaviour
    {
        [SerializeField] private RtlText question;
        [SerializeField] private Dropdown answer;
        private int correctOption;

        internal void Init(string questionText, string[] answers, int correctAnswer)
        {
            question.text = questionText;
            for(var i = 0; i < 4; i++) 
                answer.options[i + 1].text = answers[i];
            correctOption = correctAnswer;
        }

        internal bool IsCorrect => answer.value == correctOption;

        internal void ResetQuestion()
        {
            answer.value = 0;
        }
    }
}