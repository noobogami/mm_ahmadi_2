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
            
            _questionsAndAnswers = g.dbQuestions;
            for (var i = 0; i < _questionsAndAnswers.Length; i++)
                questions[i].Init(_questionsAndAnswers[i].qa);

            //_qualifiedScore = g.QualifiedScore;
        }

        public override void ResetRoom()
        {
            foreach (var q in questions)
                q.ResetAnswers();
        }

        public override void CheckAnswers()
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