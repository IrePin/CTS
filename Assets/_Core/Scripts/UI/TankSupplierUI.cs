using _Core.Scripts.Mouse;
using _Core.Scripts.Tank;
using UnityEngine;

namespace _Core.Scripts.UI
{
    public class TankSupplierUI : MonoBehaviour
    {
        [SerializeField] private TankSupplier supplier;
        [SerializeField] private OnHoldMouseAction levelUpButton;
        [SerializeField] private OnHoldMouseAction levelDownButton;

        private void Start()
        {
            levelUpButton.OnButtonDown += supplier.StartSupplying;
            levelUpButton.OnButtonUp += supplier.StopOperating;
            
            levelDownButton.OnButtonDown += supplier.StartDraining;
            levelDownButton.OnButtonUp += supplier.StopOperating;
        }
    }
}
