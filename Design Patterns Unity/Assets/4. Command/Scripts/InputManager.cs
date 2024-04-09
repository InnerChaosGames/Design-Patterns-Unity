using DesignPatterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class InputManager : MonoBehaviour
    {
        private PlayerMovement playerMovement;

        [SerializeField]
        private float inputDelay = 0.1f;

        private float currentDelay = 0;

        private void Awake()
        {
            playerMovement = GetComponent<PlayerMovement>();
        }

        private void Update()
        {
            if (currentDelay < inputDelay)
            {
                currentDelay += Time.deltaTime;
                return;
            }

            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
            {
                RunPlayerCommand(Vector2Int.up);
                currentDelay = 0;
            }
            if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
            {
                RunPlayerCommand(Vector2Int.down);
                currentDelay = 0;
            }
            if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                RunPlayerCommand(Vector2Int.left);
                currentDelay = 0;
            }
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                RunPlayerCommand(Vector2Int.right);
                currentDelay = 0;
            }
            if (Input.GetKeyDown(KeyCode.Q))
            {
                CommandInvoker.UndoCommand();
                currentDelay = 0;
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                CommandInvoker.RedoCommand();
                currentDelay = 0;
            }
        }

        private void RunPlayerCommand(Vector2Int position)
        {
            if (playerMovement == null)
            {
                return;
            }

            if (playerMovement.IsValidMove(position))
            {
                // issue the command and save to undo stack
                ICommand command = new MoveCommand(playerMovement, position);

                print("Execute command");
                // we run the command immediately here, but you can also delay this for extra control over the timing
                CommandInvoker.ExecuteCommand(command);
            }
        }
    }
}