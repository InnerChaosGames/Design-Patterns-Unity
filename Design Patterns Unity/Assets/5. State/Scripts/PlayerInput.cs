using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class PlayerInput : MonoBehaviour
    {
        public float Horizontal => horizontal;
        public bool IsJumping { get => isJumping; set => isJumping = value; }

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