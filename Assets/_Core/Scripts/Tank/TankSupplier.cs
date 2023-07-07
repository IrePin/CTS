using UnityEngine;

namespace _Core.Scripts.Tank
{
    public class TankSupplier: MonoBehaviour
    {
        [SerializeField] private TankCube waterTank;
        [SerializeField] private float waterSupplyLevelRate;
        private bool _isOperating;
        private float _currentSupplyLevelRate;

        public void StartSupplying()
        {
            _currentSupplyLevelRate = waterSupplyLevelRate;
            _isOperating = true;
        }

        public void StartDraining()
        {
            _currentSupplyLevelRate = -waterSupplyLevelRate;
            _isOperating = true;
        }

        public void StopOperating()
        {
            _isOperating = false;
        }

        private void Update()
        {
            if (!_isOperating) return;
            float waterLevel = waterTank.WaterLevel;
            waterLevel += _currentSupplyLevelRate * Time.deltaTime;
            waterTank.SetWaterLevelClamp(waterLevel);
        }  
    }
}