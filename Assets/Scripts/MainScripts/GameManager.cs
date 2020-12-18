using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;
using UPersian.Components;
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


        [SerializeField] private GameObject black;
        [SerializeField] private Transform mainCamera;
        [SerializeField] private Transform[] doors;

        [Header("Guide and Forms")] 
        [SerializeField] private GuideHandler guide;
        [SerializeField] private FormHandler form;
        [SerializeField] private GameObject book;
        
        [Header("Rooms")] 
        [SerializeField] private QuestionRoom room01;
        [SerializeField] private ConnectionPuzzleRoom room02;
        [SerializeField] private DropDownRoom room03;
        [SerializeField] private TypeRoom room04;
        [SerializeField] private DragNDropRoom room05;

        [Header("Other SHIT!")] 
        [SerializeField] private Button enteringRoomOptions;
        [SerializeField] private RtlText enteringBtnText;

        [SerializeField] private GameObject exitWarning;


        private List<BaseRoom> _rooms;
        private bool _isInHall;
        internal int CurrentShowingRoom;

        void Start()
        {
            VideoHandler._.PlayIntro();
        }

        private void Init()
        {
            //UIManager._.ShowBlack(true);
            _rooms = new List<BaseRoom>() {room01, room02, room03, room04, room05};

            HideAllRooms();

            guide.Init();

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
            UIManager._.gameObject.SetActive(true);
            UIManager._.ShowBlack(false);
            guide.ShowGuide(true);
            form.ShowForm(true);
            book.SetActive(false);
            black.SetActive(false);
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

            if (Input.GetKeyDown(KeyCode.UpArrow) && CurrentShowingRoom < 10)
            {
                CurrentShowingRoom++;
                GoToDoor(CurrentShowingRoom);
            }

            if (Input.GetKeyDown(KeyCode.DownArrow) && CurrentShowingRoom > 0)
            {
                CurrentShowingRoom--;
                GoToDoor(CurrentShowingRoom);
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad1) && CurrentShowingRoom > 0)
            {
                CurrentShowingRoom = 1;
                ShowCurrentRoom();
            }
            
            if (Input.GetKeyDown(KeyCode.Keypad1)) ShowRoom(1);
            if (Input.GetKeyDown(KeyCode.Keypad2)) ShowRoom(2);
            if (Input.GetKeyDown(KeyCode.Keypad3)) ShowRoom(3);
            if (Input.GetKeyDown(KeyCode.Keypad4)) ShowRoom(4);
            if (Input.GetKeyDown(KeyCode.Keypad5)) ShowRoom(5);
            if (Input.GetKeyDown(KeyCode.Keypad6)) ShowRoom(6);
            if (Input.GetKeyDown(KeyCode.Keypad7)) ShowRoom(7);
            if (Input.GetKeyDown(KeyCode.Keypad8)) ShowRoom(8);
            if (Input.GetKeyDown(KeyCode.Keypad9)) ShowRoom(9);
            if (Input.GetKeyDown(KeyCode.Keypad0)) ShowRoom(10);
        }

        private void ShowRoom(int roomNum)
        {
            CurrentShowingRoom = roomNum;
            ShowCurrentRoom();
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
                mainCamera.DORotateQuaternion(Quaternion.Euler(new Vector3(0, 0, 0)), 2);
                return;
            }

            mainCamera.DOMoveZ(doors[doorNum - 1].position.z, 2).onComplete += CameraMovingEnded;
            mainCamera.DORotateQuaternion(Quaternion.Euler(new Vector3(0, doorNum > 5 ? 90 : -90, 0)), 2);
        }

        private void CameraMovingEnded()
        {
            cameraMoving = false;
            EnterRoomBtn();
        }

        private void EnterRoomBtn()
        {
            if (CurrentShowingRoom != 0)
                enteringRoomOptions.interactable = !Stat.Ins.games[CurrentShowingRoom - 1].passed;
            enteringRoomOptions.gameObject.SetActive(CurrentShowingRoom != 0);
            enteringBtnText.text = "ورود به مرحله " + CurrentShowingRoom;
        }

        public void ShowCurrentRoom()
        {
            _isInHall = false;
            enteringRoomOptions.gameObject.SetActive(false);
            _rooms[CurrentShowingRoom - 1].ShowRoom(Stat.Ins.games[CurrentShowingRoom - 1].roomName);
        }

        public void ShowGuide()
        {
            if (_isInHall)
                guide.ShowGuide(true);
            else
                _rooms[CurrentShowingRoom - 1].ShowGuide();
        }

        public void ShowBook()
        {
            book.SetActive(true);
        }

        public void Back()
        {
            if (_isInHall)
                exitWarning.SetActive(true);
            else
                ShowHall();
        }

        public void ExitGame()
        {
            Application.Quit();
        }
    }
}