using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace _Core.Scripts.Mouse
{
    public class OnHoldMouseAction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
    {
        public event Action OnButtonDown;
        public event Action OnButtonUp;

        public void OnPointerUp(PointerEventData eventData)
        {
            OnButtonUp?.Invoke();
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonDown?.Invoke();
        }
    }
}