using UnityEngine;
using UPersian.Components;

namespace MainScripts
{
    public class FormHandler : MonoBehaviour
    {
        [SerializeField] private RtlText nameText;

        internal void ShowForm(bool show)
        {
            gameObject.SetActive(show);
        }

        public void SaveForm()
        {
            //HideForm();
            Stat.Ins.PlayerName = nameText.BaseText;
            ShowForm(false);
        }
    }
}
