using UnityEngine;

namespace MainScripts
{
    public class QuestionRoom : BaseRoom
    {
        [SerializeField] private Question[] questions;

        private Stat.DBQuestion[] _questionsAndAnswers;
        //private int _qualifiedScore;


        internal override void Init(int roomNum)
        {
            num = roomNum;
            var g = Stat.Ins.games[num];
            
            _questionsAndAnswers = g.DbQuestions;
            for (var i = 0; i < _questionsAndAnswers.Length; i++)
                questions[i].Init(_questionsAndAnswers[i].qa);

            //_qualifiedScore = g.QualifiedScore;
            _score = 0;
            ShowFailWarning(false);
            ShowCongratsWarning(false);
        }

        public override void ResetRoom()
        {
            foreach (var q in questions)
                q.ResetAnswers();
        }

        public void CheckAnswers()
        {
            for (var i = 0; i < _questionsAndAnswers.Length; i++)
            {
                print($"answer was {_questionsAndAnswers[i].answer} and your choice was {questions[i].GetAnswer() + 1}");
                if (questions[i].GetAnswer() + 1 == _questionsAndAnswers[i].answer)
                    _score++;
            }

            if (_score < questions.Length)
            {
                ShowFailWarning();
                _score = 0;
            }
            else
                ShowCongratsWarning();
        }
    }
}