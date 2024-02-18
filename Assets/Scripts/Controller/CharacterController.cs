using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Sample
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private MoveComponent _playerMoveComponent;

        private Vector3 _userInput;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            _playerMoveComponent = player.GetComponent<MoveComponent>();
        }

        private void Update()
        {
            _userInput = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            _playerMoveComponent.MoveDirection = _userInput;
        }
    }
}