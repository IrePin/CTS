using UnityEngine;

namespace _Core.Scripts.Pipe
{
    public class PipeLift : MonoBehaviour
    {
        [SerializeField] private Pipe _pipe;
        [SerializeField] private Vector2 yLocalLimits;
        [SerializeField] private float liftRate;
        private float _currentLiftRate;
        private bool _isOperating;
        private Transform PipeTransform => _pipe.transform;

        private void Start()
        {
            SetLevel(_pipe.Level);
        }

        public void StartLiftingUp()
        {
            _currentLiftRate = liftRate;
            _isOperating = true;
        }

        public void StopOperating()
        {
            _isOperating = false;
        }

        public void StartLiftingDown()
        {
            _currentLiftRate = -liftRate;
            _isOperating = true;
        }

        private void Update()
        {
            if (!_isOperating) return;
            float y = PipeTransform.localPosition.y;
            y += _currentLiftRate * Time.deltaTime;
            y = Mathf.Clamp(y, yLocalLimits.x, yLocalLimits.y);
            SetLevel(y);
        }

        private void SetLevel(float level)
        {
            Vector3 pipeLocalPosition = PipeTransform.localPosition;
            pipeLocalPosition.y = level;
            PipeTransform.localPosition = pipeLocalPosition;
            _pipe.SetLevel(level);
        }
    }
}