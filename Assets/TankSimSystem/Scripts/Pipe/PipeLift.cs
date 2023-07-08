using UnityEngine;

namespace TankSimSystem
{
    public class PipeLift : MonoBehaviour
    {
        [SerializeField] private Pipe pipe;
        [SerializeField] private Vector2 yLocalLimits;
        [SerializeField] private float minPipeHeight = 0.5f;

        [SerializeField] private float liftRate;
        private float _currentLiftRate;
        private bool _isOperating;
        private Transform PipeTransform => pipe.transform;

        private void Start()
        {
            SetPipeHeight(minPipeHeight);
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
            float currentHeight = PipeTransform.localPosition.y;
            float newHeight = currentHeight + _currentLiftRate * Time.deltaTime;
            newHeight = Mathf.Clamp(newHeight, minPipeHeight, yLocalLimits.y);
            SetPipeHeight(newHeight);
        }

        private void SetPipeHeight(float height)
        {
            Vector3 pipeLocalPosition = PipeTransform.localPosition;
            pipeLocalPosition.y = height;
            PipeTransform.localPosition = pipeLocalPosition;
            pipe.SetLevel(height);
        }
    }
}