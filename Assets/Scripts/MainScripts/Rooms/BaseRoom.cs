using UnityEngine;
using UPersian.Components;

namespace MainScripts
{
    public abstract class BaseRoom : MonoBehaviour
    {
        [SerializeField] protected RtlText roomName;
        [SerializeField] protected GameObject failWarning;
        [SerializeField] protected GameObject congratsWarning;
        [SerializeField] protected GameObject guide;
        
        protected int num;
        protected int _score;
        internal void HideRoom()
        {
            gameObject.SetActive(false);
        }

        internal void ShowRoom(string rName)
        {
            roomName.text = rName;
            gameObject.SetActive(true);
            _score = 0;
            ShowFailWarning(false);
            ShowCongratsWarning(false);
            ShowGuide();
        }

        internal abstract void Init(int roomNum);
        public abstract void ResetRoom();

        public abstract void CheckAnswers();
        

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
            Stat.Ins.games[GameManager._.CurrentShowingRoom - 1].passed = true;
            Stat.Ins.Level++;
            var shit = Stat.Ins.games[GameManager._.CurrentShowingRoom - 1].tries;
            Stat.Ins.Score += (10 - (shit < 3? shit: 3));
            GameManager._.ShowHall();
        }

        internal void ShowGuide()
        {
            guide.SetActive(true);
        }
    }
}
