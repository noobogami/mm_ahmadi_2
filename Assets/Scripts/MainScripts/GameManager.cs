
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;

namespace MainScripts
{
    public class GameManager : MonoBehaviour
    {
        internal static GameManager _;

        void Awake()
        {
            _ = this;
            Init();
        }




        [SerializeField] private Transform mainCamera;
        [SerializeField] private Transform[] doors;
        [Header("Rooms")]
        [SerializeField] private QuestionRoom room01;
        [Header("Other SHIT!")]
        [SerializeField] private Button enteringRoomOptions;



        private List<BaseRoom> _rooms;
        private bool _isInHall;
        internal int CurrentShowingRoom;
    
        void Start()
        {
            VideoHandler._.PlayIntro();
        }

        private void Init()
        {
            UIManager._.ShowBlack(true);
            _rooms = new List<BaseRoom>()
            {
                room01
            };


            HideAllRooms();
            
            GuideHandler._.Init();
        
            _isInHall = false;
            CurrentShowingRoom = 0;
            cameraMoving = false;
            
            enteringRoomOptions.gameObject.SetActive(false);
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
            UIManager._.ShowBlack(false);
            GuideHandler._.ShowGuide(true);
            FormHandler._.ShowForm(true);
            ShowHall();
        }

        public void ShowHall()
        {
            HideAllRooms();
            EnterRoomBtn();
            _isInHall = true;
        
        }

        void Update()
        {
            if (!_isInHall || cameraMoving) return;
        
            if(Input.GetKeyDown(KeyCode.UpArrow) && CurrentShowingRoom < 10)
            {
                CurrentShowingRoom++;
                GoToDoor(CurrentShowingRoom);
            }
            if(Input.GetKeyDown(KeyCode.DownArrow) && CurrentShowingRoom > 0)
            {
                CurrentShowingRoom--;
                GoToDoor(CurrentShowingRoom);
            }
        }

        private bool cameraMoving;
        private void GoToDoor(int doorNum)
        {
            cameraMoving = true;
            enteringRoomOptions.gameObject.SetActive(false);
            //print($"showing the fucking door number : {currentShowingRoom}");
            if (doorNum == 0)
            {
                mainCamera.DOMoveZ(0, 2).onComplete += CameraMovingEnded;
                mainCamera.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0,0)), 2);
                return;
            }
            mainCamera.DOMoveZ(doors[doorNum - 1].position.z, 2).onComplete += CameraMovingEnded;
            mainCamera.DORotateQuaternion(Quaternion.Euler(new Vector3(0, doorNum % 2 == 0? 90 : -90, 0)), 2);
        }

        private void CameraMovingEnded()
        {
            cameraMoving = false;
            EnterRoomBtn();
        }

        private void EnterRoomBtn()
        {
            if(CurrentShowingRoom != 0)
                enteringRoomOptions.interactable = !Stat.Ins.games[CurrentShowingRoom - 1].Passed;
            enteringRoomOptions.gameObject.SetActive(CurrentShowingRoom != 0);
        }

        public void ShowCurrentRoom()
        {
            enteringRoomOptions.gameObject.SetActive(false);
            _rooms[CurrentShowingRoom - 1].ShowRoom(Stat.Ins.games[CurrentShowingRoom - 1].RoomName);
        }
    }
} 