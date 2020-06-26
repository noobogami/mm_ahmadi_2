using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UPersian.Components;

public class Question : MonoBehaviour
{
    [SerializeField] private RtlText[] questionAndAnswers;
    [SerializeField] private Toggle[] answers;

    internal void Init(string[] questionAnswers)
    {
        for (var i = 0; i < 5; i++)
            questionAndAnswers[i].text = questionAnswers[i];
        foreach (var a in answers)
            a.SetValueWithoutNotify(false);
    }

    internal int GetAnswer()
    {
        for (var i = 0; i < 4; i++)
            if (answers[i].value)
                return i;
        return 0;
    }
}
