using UnityEngine;

namespace TankSimSystem.UI
{
    public class PipeVisual : MonoBehaviour
    {
        [SerializeField] private Valve valve;
        [SerializeField] private Material onValveOpenMaterial;
        [SerializeField] private Material onValveClosedMaterial;
        [SerializeField] private MeshRenderer visual;

        private void OnEnable()
        {
            valve.OnOpen += OnValveOpen;
            valve.OnClose += OnValveClose;
        }

        private void OnValveOpen()
        {
            visual.material = onValveOpenMaterial;
        }

        private void OnValveClose()
        {
            visual.material = onValveClosedMaterial;
        }

        private void OnDisable()
        {
            valve.OnOpen -= OnValveOpen;
            valve.OnClose -= OnValveClose;
        }
    }
}