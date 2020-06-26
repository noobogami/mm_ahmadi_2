using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class RoomHandler : MonoBehaviour
{

    [SerializeField] private RtlText[] qa;

    private string[][] _allQA;
    internal void HideRoom()
    {
        gameObject.SetActive(false);
    }

    internal void ShowRoom(string[][] qaList)
    {
        _allQA = qaList;
        for (var i = 0; i < 5; i++)
        {
            qa[i].text = _allQA[0][i];
        }
        gameObject.SetActive(true);
    }
}
