using UnityEngine; // imports the unity engine library which incudes basic functions like monobehaviour, vector3, collision, rigidbody, transform etc
using UnityEngine.Tilemaps; // imports the tilemaps library

public class PlayerWorld : MonoBehaviour // inherits from monobehaviour to use its functions like start, update, oncollisionenter2d etc
{
    [SerializeField] private Tilemap World;

    private void Start() // called before the first frame update means that it wil run once when the game starts
    {
        Vector3Int startcell = World.WorldToCell(transform.position); // this line gets the cell position of the player
        Vector3 Center = World.GetCellCenterWorld(startcell); // this line get the gameobject to the center of the cell, so it will not be on the edge of the cell
    }
    private void Update() // called once per frame
    {
        Inputs(); // check for inputs every frame
    }

    private void Move(Vector3Int direction) // function to move the player in a speific direction throughs inputs
    {
        Vector3 WorldDirection = World.CellToWorld(direction);
        Vector3Int currentBlock = World.WorldToCell(transform.position); // get the current block the player is on
        Vector3Int NextBlock = currentBlock + direction; // get the next block the player will move to based on the diretion input
        

        
        {

            if (World.HasTile(NextBlock)) // check if there is title in the next block
            {
                //     Debug.Log("Obstacle at " + NextBlock); // debug log to show the obstacle in the console
            }

            else
            {
                //       Debug.Log("Moving to " + NextBlock); // debug log to show the next block the player is moving to in the console

                Vector3 Center = World.GetCellCenterWorld(NextBlock); // get the center of the next cell/block
                transform.position = Center;    // move the player to the center of the cell declared above

            }
        }
        }
    private void Inputs() // function to check for inputs
    {
        if (Input.GetKeyDown(KeyCode.W)) Move(Vector3Int.up);
        if (Input.GetKeyDown(KeyCode.S)) Move(Vector3Int.down);
        if (Input.GetKeyDown(KeyCode.A)) Move(Vector3Int.left);
        if (Input.GetKeyDown(KeyCode.D)) Move(Vector3Int.right);
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        ContactPoint2D contact = collision.contacts[0]; // get the contact point of the collision
        Vector2 normal = contact.normal; // get the normal of the contact point

        if (collision.gameObject.TryGetComponent<Ipushable>(out Ipushable pushable)) // check if the collider has the Ipushable interface if yes then it will call the pushing function from the interface
        {
            Vector3Int collisionDirection = Vector3Int.zero; // initialize the collision direction variable

            if (Mathf.Abs(normal.x) > Mathf.Abs(normal.y))
            {
                if (normal.x > 0)
                {
                    collisionDirection = Vector3Int.left; // if the normal x is greater than y and normal x is positive then the collision direction is right
                    Debug.Log("Box is collided from right side and moving to left");
                }
                else
                {
                    collisionDirection = Vector3Int.right; // if the normal x is greater than y and normal x is negative then the collision direction is left
                    Debug.Log("Box is collided from left side and moving to right");
                }
            }
            else
            {
                if (normal.y > 0)
                {
                    collisionDirection = Vector3Int.down; // if the normal y is greater than x and normal y is positive then the collision direction is up
                    Debug.Log("Box is collided from up side and moving to down");
                }
                else
                {
                    collisionDirection = Vector3Int.up; // if the normal y is greater than x and normal y is negative then the collision direction is down
                    Debug.Log("Box is collided from down side and moving to up");
                }
            }

            pushable.Pushing(collisionDirection); // call the pushing function from the Ipushable interface
        }
    }

}
public interface Ipushable
{
    public void Pushing(Vector3Int direction); // function to be implemented by the class that inherits this interface
}
