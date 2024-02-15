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
            //TODO: Реализовать покадровый поворот через transform с помощью методов
            //Quaternion.RotateTowards, Quaternion.LookRotation и
            //параметров rotationSpeed, rotationDirection и Time.deltaTime;
            //если направление перемещения ноль, то поворот не происходит
        }
    }
}