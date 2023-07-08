using System;
using UnityEngine;

namespace TankSimSystem
{
    public class TankCube : MonoBehaviour
    {
        private const float MaxWaterLevel = 10f;
        [field: SerializeField] public float WaterLevel { get; private set; }

        [Header("TankVolume")] 
        
        [SerializeField] private float height;
        [SerializeField] private  float length;
        [SerializeField] private float width;


        public float TankVolume => length * width * height; 
        public float WaterVolume => TankVolume * (WaterLevel / 10);
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
            Debug.Log("WaterLevelNormalized = " + WaterLevelNormalized);
            Debug.Log("TankVolume = " + TankVolume);
            Debug.Log("WaterVolume = " + WaterVolume);
        }
        public void AddVolume(float volume)
        {
            var dh = volume / TankVolume;
            SetWaterLevel(WaterLevel + dh);
        }
    }
}