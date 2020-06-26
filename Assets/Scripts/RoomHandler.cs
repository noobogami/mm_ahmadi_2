using Boo.Lang;
using UnityEngine;
using UPersian.Components;
using static Stat;

public class RoomHandler : MonoBehaviour
{

    [SerializeField] private Question[] questions;

    private DBQuestion[] _allQA;
    internal void HideRoom()
    {
        gameObject.SetActive(false);
    }

    internal void ShowRoom(DBQuestion[] qaList)
    {
        _allQA = qaList;
        for (var i = 0; i < 5; i++)
        {
            //qa[i].text = _allQA[0][i];
        }
        gameObject.SetActive(true);
    }

}
