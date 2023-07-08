using UnityEngine;

namespace TankSimSystem
{
    public class WaterLevelVisual : MonoBehaviour
    {
        [SerializeField] private TankCube tankCube;
        [SerializeField] private Transform cubeTransform; // Reference to the cube object's Transform component

        private Vector3 _initialScale; // Initial scale of the cube
        private const float MaxHeight = 1f; // Maximum height of the cube

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