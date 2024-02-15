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

        private void Update()
        {
            if (rotationDirection == Vector3.zero)
            {
                return;
            }
            
            float deltaAngle = rotationSpeed * Time.fixedDeltaTime;
            
            Quaternion currentRotation = transform.rotation;
            Quaternion targetRotation  = Quaternion.LookRotation(rotationDirection);
            Quaternion newRotation = Quaternion.RotateTowards(currentRotation, targetRotation, deltaAngle);
            
            transform.rotation = newRotation;
        }
    }
}