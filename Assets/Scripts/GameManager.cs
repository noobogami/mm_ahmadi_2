using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    internal static GameManager _;

    void Awake()
    {
        _ = this;
    }




    [SerializeField] private Transform mainCamera;
    [SerializeField] private Transform[] doors;
    [SerializeField] private RoomHandler[] rooms;
    [SerializeField] private GameObject guide;



    private bool _isInHall;
    
    void Start()
    {
        Init();
    }

    private void Init()
    {
        foreach (var room in rooms)
        {
            room.HideRoom();
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
            GoToDoor(Stat.Ins.currentRoom);
    }

    private void GoToDoor(int doorNum)
    {
        mainCamera.DOMoveZ(doors[doorNum].position.z, 2);
        mainCamera.DORotate(new Vector3(0, -90, 0), 2);
    }

    public void ShowCurrentRoom()
    {
        rooms[Stat.Ins.currentRoom].ShowRoom(Stat.Ins.games[0].DbQuestions);
    }
} 