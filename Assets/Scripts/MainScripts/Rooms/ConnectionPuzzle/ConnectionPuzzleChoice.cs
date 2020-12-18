using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UPersian.Components;

public class ConnectionPuzzleChoice : MonoBehaviour
{
    [SerializeField] private RtlText text;
    internal void Init(string t)
    {
        text.text = t;
    }
}
