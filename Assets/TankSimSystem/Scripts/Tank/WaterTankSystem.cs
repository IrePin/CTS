using UnityEngine;

namespace TankSimSystem
{
    public class WaterTankSystem : MonoBehaviour
    {
        [SerializeField] private TankCube leftWaterTank;
        [SerializeField] private TankCube rightWaterTank;
        [SerializeField] private Pipe pipe;
        [SerializeField] private Valve valve;
        [SerializeField] private WaterFlow waterFlow;
        private bool _isTanksConnected;

        private void Start()
        {
            valve.OnOpen += OnValveOpen;
            valve.OnClose += OnValveClose;
        }

        private void OnValveClose()
        {
            _isTanksConnected = false;
        }

        private void OnValveOpen()
        {
            _isTanksConnected = true;
        }

        private void Update()
        {
            if (!_isTanksConnected) return;
            float pipeLevel = pipe.Level;
            float maxTankLevel = Mathf.Max(leftWaterTank.WaterLevel, rightWaterTank.WaterLevel);
            if (pipeLevel >= maxTankLevel) return;
            float transferVolume = GetWaterFlowRate() * Time.deltaTime;
            if (leftWaterTank.WaterLevel > rightWaterTank.WaterLevel)
            {
                transferVolume = Mathf.Min(GetVolumeTillPipe(leftWaterTank), transferVolume);
                TransferWaterClamped(leftWaterTank, rightWaterTank, transferVolume);
            }
            else if (rightWaterTank.WaterLevel > leftWaterTank.WaterLevel)
            {
                transferVolume = Mathf.Min(GetVolumeTillPipe(rightWaterTank), transferVolume);
                TransferWaterClamped(rightWaterTank, leftWaterTank, transferVolume);
            }
        }

        private void TransferWaterClamped(TankCube fromTank, TankCube toTank, float volume)
        {
            var fromWaterVolume = fromTank.WaterVolume;
            var toWaterVolume = toTank.WaterVolume;
            var maxTransferVolume = (fromWaterVolume - toWaterVolume) / 2f;
            var clampedTransferVolume = Mathf.Min(volume, maxTransferVolume);
            // Transfer water
            fromTank.AddVolume(-clampedTransferVolume);
            toTank.AddVolume(clampedTransferVolume);
        }

        private float GetVolumeTillPipe(TankCube tank)
        {
            float tankLevel = tank.WaterLevel;
            float pipeLevel = pipe.Level;
            float dLevel = tankLevel - pipeLevel;
            float area = tank.TankVolume;
            return dLevel * area;
        }

        private float GetWaterFlowRate()
        {
            return waterFlow.GetWaterFlowRate();
        }
    }
}
