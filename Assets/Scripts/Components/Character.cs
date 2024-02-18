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
            if (!_moveComponent.enabled && !_rotationComponent.enabled)
            {
                return;
            }
            
            if (_healthComponent.Health == 0)
            {
                _moveComponent.enabled = !_moveComponent.enabled;
                _rotationComponent.enabled = !_rotationComponent.enabled;
            }
            
            _rotationComponent.RotationDirection = _moveComponent.MoveDirection;
        }
    }
}