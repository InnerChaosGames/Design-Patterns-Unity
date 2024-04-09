using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal => horizontal;
        public bool IsJumping { get => IsJumping; set => IsJumping = value; }

        private float horizontal;
        private bool isJumping;
        private float xInput;
        private float yInput;

        private void Update()
        {
            HandleInput();
        }

        private void HandleInput()
        {
            horizontal = Input.GetAxisRaw("Horizontal");
            isJumping = Input.GetKeyDown(KeyCode.Space);
        }
    }
}