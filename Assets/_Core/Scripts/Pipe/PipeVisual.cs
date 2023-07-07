using UnityEngine;
namespace _Core.Scripts.Pipe
{
    public class PipeVisual: MonoBehaviour
    {
        
        [SerializeField] private Valve.Valve valve;
        [SerializeField] private Material onValveOpenMaterial;
        [SerializeField] private Material onValveClosedMaterial;
        [SerializeField] private MeshRenderer visual;

        private void Start()
        {
            valve.OnOpen += OnValveOpen;
            valve.OnClose += OnValveClose;
        }

        private void OnValveOpen()
        {
            visual.material = onValveOpenMaterial;
        }private void OnValveClose()
        {
            visual.material = onValveClosedMaterial;
        }
    }
}