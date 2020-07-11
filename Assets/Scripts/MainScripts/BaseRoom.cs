using UnityEngine;
using UPersian.Components;

namespace MainScripts
{
    public abstract class BaseRoom : MonoBehaviour
    {
        [SerializeField] protected RtlText roomName;
        [SerializeField] protected GameObject failWarning;
        [SerializeField] protected GameObject congratsWarning;
        
        protected int num;
        protected int _score;
        internal void HideRoom()
        {
            gameObject.SetActive(false);
        }

        internal void ShowRoom(string name)
        {
            roomName.text = name;
            gameObject.SetActive(true);
        }

        internal abstract void Init(int roomNum);
        public abstract void ResetRoom();
        

        protected void ShowFailWarning(bool show = true)
        {
            failWarning.SetActive(show);
            if(show)
                Stat.Ins.games[GameManager._.CurrentShowingRoom - 1].tries++;
        }
        protected void ShowCongratsWarning(bool show = true)
        {
            congratsWarning.SetActive(show);
        }

        public void SubmitAnswer()
        {
            Stat.Ins.games[GameManager._.CurrentShowingRoom - 1].Passed = true;
            Stat.Ins.Level++;
            var shit = Stat.Ins.games[GameManager._.CurrentShowingRoom - 1].tries;
            Stat.Ins.Score += (10 - (shit < 3? shit: 3));
            GameManager._.ShowHall();
        }
    }
}
