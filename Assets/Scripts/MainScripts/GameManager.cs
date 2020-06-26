using Boo.Lang;
using DG.Tweening;
using UnityEngine;

namespace MainScripts
{
    public class GameManager : MonoBehaviour
    {
        internal static GameManager _;

        void Awake()
        {
            _ = this;
        }




        [SerializeField] private Transform mainCamera;
        [SerializeField] private Transform[] doors;
        [SerializeField] private Room01 room01;
        [SerializeField] private GameObject guide;



        private List<BaseRoom> _rooms;
        private bool _isInHall;
    
        void Start()
        {
            Init();
        }

        private void Init()
        {
            _rooms = new List<BaseRoom>()
            {
                room01
            };


            for (var i = 0; i < _rooms.Count; i++)
            {
                _rooms[i].HideRoom();
                _rooms[i].Init(i);
            }
        
            VideoHandler._.PlayIntro();
            _isInHall = false;
        }

        internal void StartGame()
        {
            guide.SetActive(true);
            ShowHall();
        }

        internal void ShowHall()
        {
            _isInHall = true;
        
        }

        void Update()
        {
            if (!_isInHall) return;
        
            if(Input.GetKey("w"))
                GoToDoor(Stat.Ins.CurrentRoom);
        }

        private void GoToDoor(int doorNum)
        {
            mainCamera.DOMoveZ(doors[doorNum].position.z, 2);
            mainCamera.DORotate(new Vector3(0, -90, 0), 2);
        }

        public void ShowCurrentRoom()
        {
            _rooms[Stat.Ins.CurrentRoom].ShowRoom();
        }
    }
} 