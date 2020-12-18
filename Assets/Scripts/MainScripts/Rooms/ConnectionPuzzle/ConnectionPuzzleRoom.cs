using System.Collections.Generic;
using UnityEngine;

namespace MainScripts
{
    public class ConnectionPuzzleRoom : BaseRoom
    {

        [SerializeField] private ConnectionPuzzleChoice[] choices;
        [SerializeField] private ConnectionPuzzleQuestion[] questions;
        internal override void Init(int roomNum)
        {
            num = roomNum;
            
            var g = Stat.Ins.games[num];
            var usedNum = new List<int>();

            for (var i = 0; i < choices.Length; i++)
            {
                choices[i].Init($"-{i + 1}- " + g.dbConnectionPuzzle[i][0]);
                var rand = Utility.RandInt(10);
                while (usedNum.Contains(rand))
                    rand = Utility.RandInt(10);
                usedNum.Add(rand);
                questions[rand].Init($"-{rand + 1}- " + g.dbConnectionPuzzle[i][1], i + 1);
            }
          
        }

        public override void ResetRoom()
        {
            foreach (var q in questions)
                q.ResetAnswers();
        }

        public override void CheckAnswers()
        {
            for (var i = 0; i < choices.Length; i++)
            {
                //print($"answer was {_questionsAndAnswers[i].answer} and your choice was {questions[i].GetAnswer() + 1}");
                if (questions[i].IsAnswerCorrect())
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
