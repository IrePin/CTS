using _Core.Scripts.Mouse;
using TMPro;
using UnityEngine;

namespace _Core.Scripts.UI
{
    public class TankLevelVisual : MonoBehaviour
    {
        [SerializeField] private TankCube waterTank;
        [SerializeField] private int precisionDigits;
        [SerializeField] private GameObject visual;
        [SerializeField] private TMP_Text percentageLabel;
        [SerializeField] private OnMouseDownAction onMouseDownAction;

        private void Start()
        {
            onMouseDownAction.Callback += ToggleVisual;
            waterTank.OnWaterLevelChangedNormalized += UpdateLabel;
            UpdateLabel(waterTank.WaterLevelNormalized);
            visual.SetActive(false);
        }

        private void ToggleVisual()
        {
            visual.SetActive(!visual.activeSelf);
        }

        private void UpdateLabel(float waterLevelNormalized)
        {
            percentageLabel.text = GetPercentage(waterLevelNormalized);
        }

        private string GetPercentage(float waterLevelNormalized)
        {
            float percentage = waterLevelNormalized * 100f;
            return percentage.ToString($"N{precisionDigits}") + "%";
        }
    }
}