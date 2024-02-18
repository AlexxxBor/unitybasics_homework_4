using System;
using UnityEngine;
using UnityEngine.TextCore.Text;

namespace Sample
{
    public sealed class CharacterController : MonoBehaviour
    {
        [SerializeField] private GameObject player;
        private MoveComponent _playerMoveComponent;

        private void Awake()
        {
            player = GameObject.FindGameObjectWithTag("Player");
            _playerMoveComponent = player.GetComponent<MoveComponent>();
        }

        private void Update()
        {
            //TODO:
            //Реализовать перемещение и поворот в нужную сторону с помощью нажатия WASD или стрелочек на клавиатуре
            _playerMoveComponent.MoveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        }
    }
}