using UnityEngine;
using UnityEngine.UI;
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
            a.SetIsOnWithoutNotify(false);
    }

    internal int GetAnswer()
    {
        for (var i = 0; i < 4; i++)
            if (answers[i].isOn)
                return i;
        return 0;
    }
}
