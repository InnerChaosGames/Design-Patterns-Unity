using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class MoveCommand : ICommand
    {
        private PlayerMovement playerMovement;
        private Vector2Int movement;

        public MoveCommand(PlayerMovement playerMovement, Vector2Int movement)
        {
            this.playerMovement = playerMovement;
            this.movement = movement;
        }

        public void Execute()
        {
            playerMovement?.
        }

        public void Undo()
        {

        }
    }
}