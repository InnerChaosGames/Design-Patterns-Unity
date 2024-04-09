using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DesignPatterns.Command
{
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField]
        private int sizeX;
        [SerializeField]
        private int sizeY;
        [SerializeField]
        private int moveSteps;
        [SerializeField]
        private PlayerPart playerPartPrefab;

        private bool[,] board;
        private Vector2Int currentPos;
        private Vector2Int lastPos;

        private List<PlayerPart> playerParts = new List<PlayerPart>();

        public Vector2Int CurrentPosition { get => currentPos; }

        private void Awake()
        {
            board = new bool[sizeX, sizeY];
        }

        public bool IsValidMove(Vector2Int pos)
        {
            Vector2Int newPos = currentPos + pos;
            return newPos.x >= 0 && newPos.y >= 0 && newPos.x < sizeX && newPos.y < sizeY
                && board[newPos.x, newPos.y] == false;
        }

        public void AddMove(Vector2Int move)
        {
            lastPos = currentPos;
            currentPos += move;
            board[currentPos.x, currentPos.y] = true;
            StartCoroutine(MovementAnim(true));
            print("oldPos: " + lastPos + " NewPos: " + currentPos);
        }

        public void RemovePos(Vector2Int move)
        {
            lastPos = currentPos;
            currentPos += move;
            board[lastPos.x, lastPos.y] = false;
            StartCoroutine(MovementAnim(false));
            print("oldPos: " + lastPos + " NewPos: " + currentPos);
        }

        private IEnumerator MovementAnim(bool add)
        {
            float diffX = (currentPos.x - transform.position.x) / moveSteps;
            float diffY = (currentPos.y - transform.position.y) / moveSteps;

            for (int i = 0; i < moveSteps; i++)
            {
                transform.position += new Vector3(diffX, diffY, 0);
                yield return new WaitForSeconds(0.01f);
            }

            if (add)
            {
                // create new body part
                var newPart = Instantiate(playerPartPrefab, new Vector3(lastPos.x, lastPos.y, 0), Quaternion.identity);
                newPart.Position = lastPos;
                //newPart.transform.SetParent(transform);
                print(newPart.Position);
                playerParts.Add(newPart);
            }
            else
            {
                print(currentPos);
                var move = playerParts.Find(x => x.Position == currentPos);
                playerParts.Remove(move);
                Destroy(move.gameObject);
            }
        }
    }
}