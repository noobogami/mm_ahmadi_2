
using System.Collections.Generic;
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
        [SerializeField] private QuestionRoom room01;
        [SerializeField] private GameObject guide;
        [SerializeField] private GameObject enteringRoomOptions;



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


            HideAllRooms();
        
            VideoHandler._.PlayIntro();
            _isInHall = false;
            
            enteringRoomOptions.SetActive(false);
        }

        private void HideAllRooms()
        {
            for (var i = 0; i < _rooms.Count; i++)
            {
                _rooms[i].HideRoom();
                _rooms[i].Init(i);
            }
        }

        internal void StartGame()
        {
            guide.SetActive(true);
            ShowHall();
        }

        internal void ShowHall()
        {
            HideAllRooms();
            _isInHall = true;
        
        }

        void Update()
        {
            if (!_isInHall) return;
        
            if(Input.GetKey(KeyCode.W))
                GoToDoor(Stat.Ins.CurrentRoom);
        }

        private void GoToDoor(int doorNum)
        {
            mainCamera.DOMoveZ(doors[doorNum].position.z, 2).onComplete += CameraMovingEnded;
            mainCamera.DORotate(new Vector3(0, -90, 0), 2);
        }

        private void CameraMovingEnded()
        {
            enteringRoomOptions.SetActive(true);
        }

        public void ShowCurrentRoom()
        {
            enteringRoomOptions.SetActive(false);
            _rooms[Stat.Ins.CurrentRoom].ShowRoom();
        }
    }
} 