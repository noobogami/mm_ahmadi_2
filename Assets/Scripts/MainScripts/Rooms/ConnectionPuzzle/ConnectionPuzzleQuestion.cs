using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UPersian.Components;

public class ConnectionPuzzleQuestion : MonoBehaviour
{
    [SerializeField] private RtlText text;
    [SerializeField] private InputField inputField;

    private int _answer;
    
    internal void Init(string t, int a)
    {
        text.text = t;
        _answer = a;
    }

    internal bool IsAnswerCorrect()
    {
        print($"answer was {_answer} and your answer is {int.Parse(inputField.text)} you stupid fuck");
        return _answer == int.Parse(inputField.text);
    }

    internal void ResetAnswers()
    {
        inputField.text = "";
    }
}
