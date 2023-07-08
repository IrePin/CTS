using System;
using UnityEngine;

namespace TankSimSystem
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