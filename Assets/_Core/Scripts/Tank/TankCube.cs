using System;
using UnityEngine;

namespace _Core.Scripts
{
    public class TankCube : MonoBehaviour
    {
        public const float MaxWaterLevel = 10f;
        [field: SerializeField] public float WaterLevel { get; private set; }

        [Header("TankVolume")] 
        
        private const float Length = 1;
        private const float Width = 4;
        private const float Height = 7;

        public float SectionArea =>
            2 * (Length * Width + Length * Height + Width * Height); // Площа бічної поверхні паралелепіпеда

        public float Volume => SectionArea * WaterLevel;
        public float WaterLevelNormalized => WaterLevel / MaxWaterLevel;
        public event Action<float> OnWaterLevelChangedNormalized;

        private void Update()
        {
            Debug.Log(WaterLevelNormalized);
        }

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
            var dh = volume / SectionArea;
            SetWaterLevel(WaterLevel + dh);
        }
    }
}