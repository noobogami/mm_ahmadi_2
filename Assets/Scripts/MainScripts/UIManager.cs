using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MainScripts;
using UnityEngine;
using UnityEngine.UI;
using UPersian.Components;

public class UIManager : MonoBehaviour
{
    internal static UIManager _;

    void Awake()
    {
        _ = this;
        Init();
    }
    
    
    
    
    
    [SerializeField] private GameObject blackScreen;

    [Header("HUD")] 
    [SerializeField] private RtlText playerName;
    [SerializeField] private RtlText score;
    [SerializeField] private RtlText level;
    [SerializeField] private Image rankObject;

    [Header("Rank Sprites")] 
    [SerializeField] private Sprite[] rankSourceImages;

    internal void Init()
    {
        gameObject.SetActive(false);
        SetLevel();
        SetScore();
    }
    
    internal void ShowBlack(bool show)
    {
        blackScreen.SetActive(show);
    }

    internal void SetPlayerName()
    {
        playerName.text = Stat.Ins.PlayerName;
    }

    internal void SetScore()
    {
        score.text = Stat.Ins.Score.ToString();
    }
    internal void SetLevel()
    {
        level.text = Stat.Ins.Level.ToString();
        rankObject.sprite = rankSourceImages[Stat.Ins.Level];
    }
}
