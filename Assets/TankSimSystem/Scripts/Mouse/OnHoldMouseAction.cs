using System;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

namespace TankSimSystem
{
    public class OnHoldMouseAction : MonoBehaviour, IPointerUpHandler, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler
    {

        private Image _image;
        public event Action OnButtonDown;
        public event Action OnButtonUp;

        private void Start()
        {
            _image = GetComponent<Image>();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnButtonUp?.Invoke();
            _image.color = Color.white;
        }

        public void OnPointerDown(PointerEventData eventData)
        {
            OnButtonDown?.Invoke();
            _image.color = Color.green;
        }
        
        public void OnPointerEnter(PointerEventData eventData)
        {
            _image.color = Color.yellow;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _image.color = Color.white;
        }
        
    }
}