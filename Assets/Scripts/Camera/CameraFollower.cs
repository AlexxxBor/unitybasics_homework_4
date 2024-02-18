using System;
using UnityEngine;

namespace Sample
{
    public sealed class CameraFollower : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        
        [SerializeField]
        private Vector3 offset;
        
        [SerializeField]
        private float smoothTime;
        

        private Vector3 _camVelocity;
        private Vector3 _positionToMove;
        private Vector3 _currentPosition;
        
        private void LateUpdate()
        {
            _currentPosition = transform.position;
            _positionToMove = target.position + offset;

            transform.position = Vector3.SmoothDamp(_currentPosition, _positionToMove, ref _camVelocity, smoothTime);
            transform.LookAt(target);
        }
    }
}