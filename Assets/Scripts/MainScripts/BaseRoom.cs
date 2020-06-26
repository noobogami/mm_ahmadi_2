using UnityEngine;

namespace MainScripts
{
    public abstract class BaseRoom : MonoBehaviour
    {
        [SerializeField] protected GameObject failWarning;
        [SerializeField] protected GameObject congratsWarning;
        
        protected int num;
        internal void HideRoom()
        {
            gameObject.SetActive(false);
        }

        internal void ShowRoom()
        {
            gameObject.SetActive(true);
        }

        internal abstract void Init(int roomNum);
    }
}
