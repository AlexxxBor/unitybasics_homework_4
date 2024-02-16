using System;
using UnityEngine;

namespace Sample
{
    [RequireComponent(typeof(HealthComponent))]
    [RequireComponent(typeof(MoveComponent))]
    [RequireComponent(typeof(RotationComponent))]
    public sealed class Сharacter : MonoBehaviour
    {
        private HealthComponent _healthComponent;
        private MoveComponent _moveComponent;
        private RotationComponent _rotationComponent;

        private void Awake()
        {
            _healthComponent = GetComponent<HealthComponent>();
            _moveComponent = GetComponent<MoveComponent>();
            _rotationComponent = GetComponent<RotationComponent>();
        }

        private void FixedUpdate()
        {
            //TODO:
            //Реализовать вращение персонажа в том же направлении, куда и двигается

            //TODO:
            //Реализовать условие перемещения и поворота:
            //перемещаться и вращаться можно если здоровье больше нуля, иначе перемещение и вращение не происходят

            if (_healthComponent.Health == 0)
            {
                _moveComponent.enabled = false;
                _rotationComponent.enabled = false;
            }
            else
            {
                _rotationComponent.RotationDirection = _moveComponent.MoveDirection;
            }
        }
    }
}