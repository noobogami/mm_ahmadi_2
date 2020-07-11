using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using MainScripts;
using UnityEngine;
using UPersian.Components;

public class UIManager : MonoBehaviour
{
    internal static UIManager _;

    void Awake()
    {
        _ = this;
    }
    
    
    
    
    
    [SerializeField] private GameObject black;

    [Header("HUD")] 
    [SerializeField] private RtlText playerName;
    [SerializeField] private RtlText score;
    [SerializeField] private RtlText level;

    internal void ShowBlack(bool show) => black.SetActive(show);

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
    }
}
