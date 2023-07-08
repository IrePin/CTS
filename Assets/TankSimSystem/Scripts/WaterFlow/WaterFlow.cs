using UnityEngine;

namespace TankSimSystem
{
    public class WaterFlow : MonoBehaviour
    {
        [SerializeField] private TankCube leftTank;
        [SerializeField] private TankCube rightTank;
        [SerializeField] private Pipe pipe;

        public float GetWaterFlowRate()
        {
            return pipe.WaterFlowRate;
        }
    }
}