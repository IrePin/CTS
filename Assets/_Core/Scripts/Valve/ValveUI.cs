using UnityEngine;
using UnityEngine.UI;

namespace _Core.Scripts.Valve
{
    public class ValveUI : MonoBehaviour
    {
        [SerializeField] private Valve valve;
        [SerializeField] private Button openValveButton;
        [SerializeField] private Button closeValveButton;

        private void Start()
        {
            openValveButton.onClick.AddListener(valve.Open);
            closeValveButton.onClick.AddListener(valve.Close);
        }
    }
}
