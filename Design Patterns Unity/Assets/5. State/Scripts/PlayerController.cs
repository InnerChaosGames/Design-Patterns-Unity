using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class PlayerController : MonoBehaviour
    {
        private PlayerInput playerInput;
        private StateMachine playerStateMachine;

        [SerializeField]
        private bool isGrounded = true;
        [SerializeField]
        private float groundedRadius = 0.5f;

        private float horizontal;
        [SerializeField]
        private float speed = 8f;
        [SerializeField]
        private float jumpingPower = 6f;

        [SerializeField]
        private Rigidbody2D rb;
        [SerializeField]
        private Transform groundCheck;
        [SerializeField]
        private LayerMask groundLayer;

        public bool IsGrounded { get => isGrounded; }
        public StateMachine PlayerStateMachine { get => playerStateMachine; }
        public Rigidbody2D RigidBody { get => rb; }

        private void Awake()
        {
            playerInput = GetComponent<PlayerInput>();

            // initialize state machine
            playerStateMachine = new StateMachine(this);
        }

        private void Start()
        {
            playerStateMachine.Initialize(playerStateMachine.idleState);
        }

        private void Update()
        {
            playerStateMachine.Update();

            isGrounded = CheckGrounded();

            if (playerInput.IsJumping && isGrounded)
            {
                print("Jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpingPower);
            }
        }

        private void LateUpdate()
        {
            Move();
        }

        private void Move()
        {
            horizontal = playerInput.Horizontal;
        }

        private void FixedUpdate()
        {
            rb.velocity = new Vector2(horizontal * speed, rb.velocity.y);
        }

        private bool CheckGrounded()
        {
            return Physics2D.OverlapCircle(groundCheck.position, 0.2f, groundLayer);
        }
    }
}