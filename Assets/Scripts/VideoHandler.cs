using System.Collections;
using System.Collections.Generic;
using MainScripts;
using UnityEngine;
using UnityEngine.Video;

public class VideoHandler : MonoBehaviour
{   
    internal static VideoHandler _;

    void Awake()
    {
        _ = this;
    }
    
    
    
    [SerializeField] private VideoPlayer player;
    
    [Header("Clips")]
    [SerializeField] private VideoClip intro;

    internal void PlayIntro()
    {
        player.clip = intro;
#if UNITY_EDITOR
        player.playbackSpeed = 100;
#endif
        player.loopPointReached +=  IntroEnded;  
        player.Play();
    }

    private void IntroEnded(VideoPlayer v)
    {
        player.gameObject.SetActive(false);
        GameManager._.StartGame();
    }
}
