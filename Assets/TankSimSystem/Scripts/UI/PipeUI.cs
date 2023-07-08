using UnityEngine;

namespace TankSimSystem.UI
{
    public class PipeUI : MonoBehaviour
    {
        [SerializeField] private PipeLift pipeLift;
        [SerializeField] private OnHoldMouseAction upButton;
        [SerializeField] private OnHoldMouseAction downButton;

        private void Start()
        {
            upButton.OnButtonDown += pipeLift.StartLiftingUp;
            upButton.OnButtonUp += pipeLift.StopOperating;

            downButton.OnButtonDown += pipeLift.StartLiftingDown;
            downButton.OnButtonUp += pipeLift.StopOperating;
        }
    }
}