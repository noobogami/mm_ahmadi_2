using System.Collections.Generic;
using UnityEngine;

namespace MainScripts
{
    public class DragNDropRoom : BaseRoom
    {
        [SerializeField] private float threshold;
        [SerializeField] private DragNDropCell[] cells;
        [SerializeField] private Transform[] containers;

        private List<int> occupiedContainer;
        internal override void Init(int roomNum)
        {
            num = roomNum;
            var g = Stat.Ins.games[num];
            var db = g.dbDragNDropTitles;
            
            var usedNum = new List<int>();
            foreach (var cell in cells)
            {
                var rand = Utility.RandInt(9);
                while (usedNum.Contains(rand))
                    rand = Utility.RandInt(9);
                usedNum.Add(rand);
                cell.Init(this, db[rand], rand);
            }
            
            occupiedContainer = new List<int>();
        }

        public override void ResetRoom()
        {
            foreach (var cell in cells) 
                cell.ResetPosition();
        }

        public override void CheckAnswers()
        {
            for (var i = 0; i < cells.Length; i++)
            {
                //print($"answer was {_questionsAndAnswers[i].answer} and your choice was {questions[i].GetAnswer() + 1}");
                if (cells[i].IsCorrect)
                    _score++;
            }

            if (_score < cells.Length)
            {
                ShowFailWarning();
                _score = 0;
            }
            else
                ShowCongratsWarning();
        }

        internal void CellDropped(DragNDropCell cell)
        {
            for(var i = 0; i < containers.Length; i++)
            {
                /*print($"----------------------------------{i}---------------------------------------");
                var pos = cell.transform.position;
                print($"{pos.x} - {pos.y}");
                pos = containers[i].position;
                print($"{pos.x} - {pos.y}");*/
                if (occupiedContainer.Contains(i) || (cell.transform.position - containers[i].position).magnitude > threshold) continue;
                cell.DropOnCell(i, containers[i].transform.position);
                occupiedContainer.Add(i);
                return;
            }

            if (cell.container >= 0)
                occupiedContainer.Remove(cell.container);
            cell.ResetPosition();
        }
    }
}