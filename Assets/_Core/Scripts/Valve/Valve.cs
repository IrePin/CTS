using System;
using UnityEngine;

namespace _Core.Scripts.Valve
{
    public class Valve : MonoBehaviour
    {
        private bool _isOpen;
        public event Action OnOpen;
        public event Action OnClose;

        public bool IsOpen => _isOpen;

        public void Open()
        {
            if (!_isOpen)
            {
                _isOpen = true;
                OnOpen?.Invoke();
            }
        }

        public void Close()
        {
            if (_isOpen)
            {
                _isOpen = false;
                OnClose?.Invoke();
            }
        }
    }
}