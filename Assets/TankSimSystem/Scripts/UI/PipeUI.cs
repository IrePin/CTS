using UnityEngine;

namespace TankSimSystem.UI
{
    public class PipeUI : MonoBehaviour
    {
        [SerializeField] private PipeLift pipeLift;
        [SerializeField] private OnHoldMouseAction upButton;
        [SerializeField] private OnHoldMouseAction downButton;

        private void OnEnable()
        {
            upButton.OnButtonDown += pipeLift.StartLiftingUp;
            upButton.OnButtonUp += pipeLift.StopOperating;

            downButton.OnButtonDown += pipeLift.StartLiftingDown;
            downButton.OnButtonUp += pipeLift.StopOperating;
        }

        private void OnDisable()
        {
            upButton.OnButtonDown -= pipeLift.StartLiftingUp;
            upButton.OnButtonUp -= pipeLift.StopOperating;

            downButton.OnButtonDown -= pipeLift.StartLiftingDown;
            downButton.OnButtonUp -= pipeLift.StopOperating;
        }
    }
}