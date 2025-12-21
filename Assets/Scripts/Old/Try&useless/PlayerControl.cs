using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerTileCheck : MonoBehaviour
{
    public Tilemap Environment;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W)) CheckTile(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.S)) CheckTile(Vector3Int.down);
        if (Input.GetKeyDown(KeyCode.A)) CheckTile(Vector3Int.left);
        if (Input.GetKeyDown(KeyCode.D)) CheckTile(Vector3Int.right);
    }

    void CheckTile(Vector3Int direction)
    {
        Vector3Int currentCell = Environment.WorldToCell(transform.position);
        Vector3Int targetCell = currentCell + direction;

        if (Environment.HasTile(targetCell))
        {
            Debug.Log("Blocked at " + targetCell);
        }
        else
        {
            Debug.Log("Empty, can move to " + targetCell);
        }
    }
}
