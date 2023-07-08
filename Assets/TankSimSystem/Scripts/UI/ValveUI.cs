using UnityEngine;
using UnityEngine.UI;

namespace TankSimSystem.UI
{
    public class ValveUI : MonoBehaviour
    {
        [SerializeField] private Valve valve;
        [SerializeField] private Button openValveButton;
        [SerializeField] private Button closeValveButton;

        private void OnEnable()
        {
            openValveButton.onClick.AddListener(valve.Open);
            closeValveButton.onClick.AddListener(valve.Close);
            closeValveButton.image.color = Color.white;
        }

        private void LateUpdate()
        {
            openValveButton.image.color = valve.IsOpen ? Color.green : Color.white;
            closeValveButton.image.color = valve.IsOpen ? Color.white : Color.green;
        }

        private void OnDisable()
        {
            openValveButton.onClick.RemoveListener(valve.Open);
            closeValveButton.onClick.RemoveListener(valve.Close);
        }
    }
}
