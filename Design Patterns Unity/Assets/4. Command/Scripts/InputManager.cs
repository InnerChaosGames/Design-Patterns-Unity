using DesignPatterns.Command;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

        }
        if (Input.GetKeyDown(KeyCode.Q))
        {

        }
        if (Input.GetKeyDown(KeyCode.E))
        {

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
            ICommand command = new MoveCommand(playerMover, movement);

            // we run the command immediately here, but you can also delay this for extra control over the timing
            CommandInvoker.ExecuteCommand(command);
        }
    }
}
