using System;
using UnityEngine;

namespace _Core.Scripts.Mouse
{
    public class OnMouseDownAction : MonoBehaviour
    {
        public event Action Callback;

        private void OnMouseDown()
        {
            Callback?.Invoke();
        }
    }
}