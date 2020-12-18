using UnityEngine;
using UPersian.Components;

namespace MainScripts
{
    public class DropDownRoom : BaseRoom
    {
        [SerializeField] private DropDownQuestions[] questions;
        internal override void Init(int roomNum)
        {
            num = roomNum;
            var g = Stat.Ins.games[num];
            var db = g.dbDropDownQuestions;
            for (var i = 0; i < questions.Length; i++)
                questions[i].Init(db[i].question, db[i].answers, db[i].correctOption);
        }

        public override void ResetRoom()
        {
            foreach (var t in questions)
                t.ResetQuestion();
        }

        public override void CheckAnswers()
        {
            for (var i = 0; i < questions.Length; i++)
            {
                //print($"answer was {_questionsAndAnswers[i].answer} and your choice was {questions[i].GetAnswer() + 1}");
                if (questions[i].IsCorrect)
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