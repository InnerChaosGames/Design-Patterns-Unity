using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.State
{
    public class PlayerStateViewer : MonoBehaviour
    {
        private PlayerController player;
        private StateMachine playerStateMachine;

        private SpriteRenderer spriteRenderer;

        private void Start()
        {
            player = GetComponent<PlayerController>();
            spriteRenderer = GetComponent<SpriteRenderer>();

            playerStateMachine = player.PlayerStateMachine;

            playerStateMachine.stateChanged += OnStateChanged;
        }

        private void OnStateChanged(IState state)
        {
            spriteRenderer.color = state.StateColor;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}