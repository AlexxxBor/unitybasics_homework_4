using System;
using UnityEngine;

namespace Sample
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(RotationComponent))]
    public sealed class Сharacter : MonoBehaviour
    {
        [SerializeField] private HealthComponent healthComponent;
        [SerializeField] private MoveComponent moveComponent;
        [SerializeField] private RotationComponent rotationComponent;

        private void Awake()
        {
            healthComponent = GetComponent<HealthComponent>();
            moveComponent = GetComponent<MoveComponent>();
            rotationComponent = GetComponent<RotationComponent>();
        }

        private void FixedUpdate()
        {
            //TODO:
            //Реализовать вращение персонажа в том же направлении, куда и двигается
            rotationComponent.RotationDirection = moveComponent.MoveDirection;

            //TODO:
            //Реализовать условие перемещения и поворота:
            //перемещаться и вращаться можно если здоровье больше нуля, иначе перемещение и вращение не происходят

            if (healthComponent.Health == 0)
            {
                moveComponent.enabled = false;
                rotationComponent.enabled = false;
            }
        }
    }
}