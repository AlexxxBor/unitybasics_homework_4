using UnityEngine;

namespace Sample
{
    public sealed class MoveComponent : MonoBehaviour
    {
        public float MoveSpeed
        {
            get => this.moveSpeed;
            set => this.moveSpeed = value;
        }

        public Vector3 MoveDirection
        {
            get => this.moveDirection;
            set => this.moveDirection = value;
        }

        [SerializeField]
        private float moveSpeed;

        [SerializeField]
        private Vector3 moveDirection;

        private void FixedUpdate()
        {
            transform.position += moveDirection * (moveSpeed * Time.fixedDeltaTime);
        }
    }
}