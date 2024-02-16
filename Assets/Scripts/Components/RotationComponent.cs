using UnityEngine;

namespace Sample
{
    public sealed class RotationComponent : MonoBehaviour
    {
        public float RotationSpeed
        {
            get => this.rotationSpeed;
            set => this.rotationSpeed = value;
        }

        public Vector3 RotationDirection
        {
            get => this.rotationDirection;
            set => this.rotationDirection = value;
        }

        [SerializeField]
        private float rotationSpeed;

        [SerializeField]
        private Vector3 rotationDirection;

        private float _deltaAngle;
        private Quaternion _currentRotation;
        private Quaternion _targetRotation;
        private Quaternion _newRotation;

        private void Update()
        {
            if (rotationDirection == Vector3.zero)
            {
                return;
            }

            _deltaAngle = rotationSpeed * Time.fixedDeltaTime;

            _currentRotation = transform.rotation;
            _targetRotation = Quaternion.LookRotation(rotationDirection);
            _newRotation = Quaternion.RotateTowards(_currentRotation, _targetRotation, _deltaAngle);

            transform.rotation = _newRotation;
        }
    }
}