using System;
using UnityEngine;

namespace TankSimSystem
{
    public class TankCube : MonoBehaviour
    {
        [field: SerializeField] public float WaterLevel { get; private set; }
        private const float MaxWaterLevel = 10f;
        [SerializeField] private float height;
        [SerializeField] private float length;
        [SerializeField] private float width;

       
        public float TankVolume => length * width * height;
        public float WaterVolume => TankVolume * (WaterLevel / MaxWaterLevel);
        public float WaterLevelNormalized => WaterLevel / MaxWaterLevel;
        public event Action<float> OnWaterLevelChangedNormalized;

        public void SetWaterLevelClamp(float waterLevel)
        {
            waterLevel = Mathf.Clamp(waterLevel, 0, MaxWaterLevel);
            SetWaterLevel(waterLevel);
        }

        private void SetWaterLevel(float waterLevel)
        {
            WaterLevel = waterLevel;
            OnWaterLevelChangedNormalized?.Invoke(WaterLevelNormalized);
        }

        public void AddVolume(float volume)
        {
            var waterLevelChange  = volume / TankVolume;
            SetWaterLevel(WaterLevel + waterLevelChange);
        }
    }
}