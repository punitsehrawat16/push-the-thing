using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UIElements;

public class BoxBehaviour : MonoBehaviour
{
    public SpriteRenderer box;    // reference to the sprite renderer component of the box
    public Rigidbody2D rb;        // reference to the rigidbody component of the box
    public Tilemap World;      // reference to the tilemap to check for obstacles
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>(); // get the rigidbody component of the box
        box = gameObject.GetComponent<SpriteRenderer>(); // get the sprite renderer component of the box
        Vector3Int startCell = World.WorldToCell(transform.position);
        Vector3 center = World.GetCellCenterWorld(startCell); // get the center of the cell where the box is spawned
        transform.position = center; // set the position of the box to the center of the cell
    }
    private void OnTriggerEnter2D(Collider2D collision) // function to check if the box is in the final target position
    {
        if (collision.CompareTag("FinalTarget"))        // check if the box is in the final target position by comparing the tag of the collider with the tag of the final target
        {
            Debug.Log("Box in the target");
            box.color = Color.yellow;                   // change the color of the box to yellow to indicate that it is in the final target position
        }
    }
    private void OnTriggerExit2D(Collider2D collision)  // function to check if the box is out of the final target position
    {
        if (collision.CompareTag("FinalTarget"))
        {
            Debug.Log("Box out of the target");
            box.color = Color.white;                    // change the color of the box to white to indicate that it is out of the final target position
        }
    }
    public void Pushing(Vector3Int direction)
    {
        Debug.Log("Box is being pushed");
        Vector3Int currentCellOfBox = World.WorldToCell(transform.position); // get the current cell of the box
        Debug.Log("Current cell of box: " + currentCellOfBox); // debug log to show the current cell of the box in the console
        Vector3Int nextCellOfBox = currentCellOfBox + direction;
        if (World.HasTile(nextCellOfBox))
        {
            Debug.Log("Obstacle at " + nextCellOfBox); // debug log to show the obstacle in the console
        }
        else
        {
            Debug.Log("Moving to " + nextCellOfBox); // debug log to show the next block the box is moving to in the console
            Vector3 center = World.GetCellCenterWorld(nextCellOfBox); // get the center of the next cell/block
            transform.position = center;    // move the box to the center of the cell declared above
        }
    }

}


