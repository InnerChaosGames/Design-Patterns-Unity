using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class IdleState : IState
    {

        private PlayerController player;

        private Color stateColor;
        public Color StateColor { get => stateColor; set => stateColor = value; }

        // pass in any parameters you need in the constructors
        public IdleState(PlayerController player, Color color)
        {
            this.player = player;
            this.stateColor = color;
        }

        public void Enter()
        {
            // code that runs when we first enter the state
            //Debug.Log("Entering Idle State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
            // if we're no longer grounded, transition to jumping
            if (!player.IsGrounded)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.jumpState);
            }

            // if we move above a minimum threshold, transition to walking
            if (Mathf.Abs(player.RigidBody.velocity.x) > 0.1f)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.walkState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            //Debug.Log("Exiting Idle State");
        }
    }
}
