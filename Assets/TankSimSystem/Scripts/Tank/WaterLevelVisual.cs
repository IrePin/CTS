using UnityEngine;

namespace TankSimSystem
{
    public class WaterLevelVisual : MonoBehaviour
    {
        [SerializeField] private TankCube tankCube;
        [SerializeField] private Transform cubeTransform;

        private Vector3 _initialScale; 
        private const float MaxHeight = 1f; 
        private void Start()
        {
            _initialScale = cubeTransform.localScale;
            UpdateCubeHeight(tankCube.WaterLevelNormalized);
            tankCube.OnWaterLevelChangedNormalized += UpdateCubeHeight;
        }

        private void UpdateCubeHeight(float normalizedValue)
        {
            float newHeight = normalizedValue * MaxHeight;
            Vector3 scale = _initialScale;
            scale.y = newHeight;
            cubeTransform.localScale = scale;
        }
    }
}