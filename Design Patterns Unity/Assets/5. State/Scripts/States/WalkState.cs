using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class WalkState : IState
    {
        private Color stateColor;
        public Color StateColor { get => stateColor; set => stateColor = value; }

        private PlayerController player;

        // pass in any parameters you need in the constructors
        public WalkState(PlayerController player, Color color)
        {
            this.player = player;
            this.stateColor = color;
        }

        public void Enter()
        {
            // code that runs when we first enter the state
            //Debug.Log("Entering Walk State");
        }

        // per-frame logic, include condition to transition to a new state
        public void Update()
        {
            // if we are no longer grounded, transition to jumping
            if (!player.IsGrounded)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.jumpState);
            }

            // if we slow to within a minimum velocity, transition to idling/standing
            if (Mathf.Abs(player.RigidBody.velocity.x) < 0.1)
            {
                player.PlayerStateMachine.TransitionTo(player.PlayerStateMachine.idleState);
            }
        }

        public void Exit()
        {
            // code that runs when we exit the state
            //Debug.Log("Exiting Walk State");
        }

    }
}
