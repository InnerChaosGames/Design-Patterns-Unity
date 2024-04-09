using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    private List<PlayerPart> playerParts;

    private void Awake()
    {
        board = new bool[sizeX, sizeY];
    }

    public bool IsValidMove(Vector2Int pos)
    {
        
        return board[pos.x, pos.y] == false && pos.x > 0 && pos.y > 0 
            && pos.x < sizeX && pos.y < sizeY;
    }

    public void AddMove(Vector2Int pos)
    {
        board[pos.x, pos.y] = true;

    }

    public void RemovePos(Vector2Int pos)
    {
        board[pos.x, pos.y] = false;
    }

    private IEnumerator MovementAnim(Vector2 newPos)
    {
        Vector2 oldPos = transform.position;

        float diffX = Mathf.Abs((newPos.x - transform.position.x) / moveSteps);
        float diffY = Mathf.Abs((newPos.y - transform.position.y) / moveSteps);
        
        for (int i = 0; i < moveSteps; i++)
        {
            transform.position += new Vector3(diffX, diffY, 0);
            yield return new WaitForSeconds(0.05f);
        }

        // create new body part
        var newPart = Instantiate(playerPartPrefab, oldPos, Quaternion.identity);
        newPart.transform.SetParent(transform);

        playerParts.Add(newPart);
    }
}
