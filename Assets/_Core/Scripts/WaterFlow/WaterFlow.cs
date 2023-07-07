
using _Core.Scripts.Tank;
using UnityEngine;

namespace _Core.Scripts.WaterFlow
{
    public class WaterFlow : MonoBehaviour
    {
        [SerializeField] private TankCube leftTank;
        [SerializeField] private TankCube rightTank;
        [SerializeField] private Pipe.Pipe pipe;

        public float GetWaterFlowRate()
        {
            return pipe.WaterFlowRate;
        }
    }
}