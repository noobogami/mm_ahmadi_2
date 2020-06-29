using UnityEngine;

namespace MainScripts
{
    public class QuestionRoom : BaseRoom
    {
        [SerializeField] private Question[] questions;

        private Stat.DBQuestion[] _questionsAndAnswers;
        private int _qualifiedScore;
        private int _score;


        internal override void Init(int roomNum)
        {
            num = roomNum;
            var g = Stat.Ins.games[num];
            
            _questionsAndAnswers = g.DbQuestions;
            for (var i = 0; i < _questionsAndAnswers.Length; i++)
                questions[i].Init(_questionsAndAnswers[i].qa);

            _qualifiedScore = g.QualifiedScore;
            _score = 0;
            ShowFailWarning(false);
            ShowCongratsWarning(false);
        }

        public void CheckAnswers()
        {
            for (var i = 0; i < _questionsAndAnswers.Length; i++)
            {
                print($"answer was {_questionsAndAnswers[i].answer} and your choice was {questions[i].GetAnswer() + 1}");
                if (questions[i].GetAnswer() + 1 == _questionsAndAnswers[i].answer)
                    _score++;
            }

            if (_score < _qualifiedScore)
                ShowFailWarning();
            else
                ShowCongratsWarning();
        }

        private void ShowFailWarning(bool show = true)
        {
            failWarning.SetActive(show);
        }
        private void ShowCongratsWarning(bool show = true)
        {
            congratsWarning.SetActive(show);
        }

        public void SubmitAnswer()
        {
            GameManager._.ShowHall();
        }
    }
}