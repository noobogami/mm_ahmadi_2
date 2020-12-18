using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UPersian.Components;

namespace MainScripts
{
    public class DragNDropCell : MonoBehaviour, IDragHandler , IPointerUpHandler, IPointerDownHandler
    {
        [SerializeField] private RtlText cellText;
        
        private DragNDropRoom roomRef;
        private Vector2 originalPosition;
        private int correctAnswer;
        internal int container;

        internal void Init(DragNDropRoom room, string text, int correct)
        {
            container = -1;
            cellText.text = text;
            roomRef = room;
            correctAnswer = correct;
            originalPosition = ((RectTransform) transform).localPosition;
        }
        
        internal void DropOnCell(int index, Vector2 position)
        {
            container = index;
            transform.position = position;
            SetZToZero();
        }

        internal void ResetPosition()
        {
            container = -1;
            ((RectTransform) transform).localPosition = originalPosition;
        }

        internal bool IsCorrect => container == correctAnswer;
        public void OnDrag(PointerEventData eventData)
        {
            ((RectTransform) transform).anchoredPosition += eventData.delta;
            SetZToZero();
        }

        private void SetZToZero()
        {
            transform.localPosition = new Vector3(transform.localPosition.x, transform.localPosition.y, 0);
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            roomRef.CellDropped(this);
        }

        public void OnPointerDown(PointerEventData eventData)
        {
        }
    }
}