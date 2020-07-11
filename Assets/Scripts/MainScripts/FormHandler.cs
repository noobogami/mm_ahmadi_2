using UnityEngine;
using UPersian.Components;

namespace MainScripts
{
    public class FormHandler : MonoBehaviour
    {
        internal static FormHandler _;

        void Awake()
        {
            _ = this;
        }
        
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
