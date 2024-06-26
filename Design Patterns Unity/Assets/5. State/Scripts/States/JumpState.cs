using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class JumpState : IState
    {
        private PlayerController player;

        private Color stateColor;
        public Color StateColor { get => stateColor; set => stateColor = value; }

        // pass in any parameters you need in the constructors
        public JumpState(PlayerController player, Color color)
        {
            this.player = player;
            this.stateColor = color;
        }

        public void Enter()
        {
            // code that runs when we first enter the state
            //Debug.Log("Entering Jump State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {

            //Debug.Log("Updating Jump State");

            if (player.IsGrounded)
            {
                if (Mathf.Abs(player.RigidBody.velocity.x) > 0.1f)
                {
                    player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.idleState);
                }
                else
                {
                    player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.walkState);
                }
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            //Debug.Log("Exiting Jump State");
        }

    }
}
