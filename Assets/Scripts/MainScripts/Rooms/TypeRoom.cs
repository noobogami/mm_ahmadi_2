using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

namespace MainScripts
{
    public class TypeRoom : BaseRoom
    {
        [SerializeField] private RtlText[] questions;
        [SerializeField] private RtlText[] answers;
        [SerializeField] private RtlText guideText;
        
        private string[] correctAnswers;
        internal override void Init(int roomNum)
        {
            num = roomNum;
            
            var g = Stat.Ins.games[num];
            var db = g.dbType;
            var usedNum = new List<int>();
            var rand = Utility.RandInt(10);
            var tempGuide = "";

            ResetRoom();
            guideText.text = "";
            correctAnswers = new string[db.Length];
            for (var i = 0; i < db.Length; i++)
            {
                questions[i].text = db[i][0];
                correctAnswers[i] = db[i][1];

                while (usedNum.Contains(rand))
                    rand = Utility.RandInt(10);
                usedNum.Add(rand);
                tempGuide += db[rand][1] + " / ";
            }

            guideText.text = tempGuide;
        }

        public override void ResetRoom()
        {
            foreach (var answer in answers)
                answer.text = "";
        }

        public override void CheckAnswers()
        {
            for (var i = 0; i < correctAnswers.Length; i++)
            {
                if (answers[i].BaseText.UnifyPersianLetters() == correctAnswers[i].UnifyPersianLetters())
                    _score++;
                else
                    print($"{i+1} - Correct answer was {correctAnswers[i].UnifyPersianLetters()} but your answer is {answers[i].BaseText.UnifyPersianLetters()} you piece of shit!");
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
