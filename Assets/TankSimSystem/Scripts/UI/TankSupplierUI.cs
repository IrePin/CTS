using UnityEngine;

namespace TankSimSystem.UI
{
    public class TankSupplierUI : MonoBehaviour
    {
        [SerializeField] private TankSupplier supplier;
        [SerializeField] private OnHoldMouseAction levelUpButton;
        [SerializeField] private OnHoldMouseAction levelDownButton;

        private void OnEnable()
        {
            levelUpButton.OnButtonDown += supplier.StartSupplying;
            levelUpButton.OnButtonUp += supplier.StopOperating;
            
            levelDownButton.OnButtonDown += supplier.StartDraining;
            levelDownButton.OnButtonUp += supplier.StopOperating;
        }
        private void OnDisable()
        {
            levelUpButton.OnButtonDown -= supplier.StartSupplying;
            levelUpButton.OnButtonUp -= supplier.StopOperating;
            
            levelDownButton.OnButtonDown -= supplier.StartDraining;
            levelDownButton.OnButtonUp -= supplier.StopOperating;
        }
    }
}
