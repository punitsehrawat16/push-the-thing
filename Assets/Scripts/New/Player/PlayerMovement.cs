using UnityEngine;
using UnityEngine.Tilemaps;
using System.Collections;
public class PlayerMovement : MonoBehaviour
{
    Rigidbody2D rb;
    BoxCollider2D boxCollider;
    [SerializeField] GameObject[] ObjToPush;
    [SerializeField] GameObject[] Obstacles;

    private bool ReadyToMove;
    public Vector2 lastMoveDirection;
    public bool isMoving;

    [SerializeField] float rayLength = 0.6f;
    [SerializeField] LayerMask wallLayer;


    private void Start()
    {
        SoundManager.instance.PlayBackgroundMusic();
        ObjToPush = GameObject.FindGameObjectsWithTag("ObjToPush");
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
        rb = GetComponent<Rigidbody2D>();
        boxCollider = GetComponent<BoxCollider2D>();
    }
    
    private void Update()
    {
        Vector2 moveinput = new Vector2(SimpleInput.GetAxisRaw("Horizontal"), SimpleInput.GetAxisRaw("Vertical"));
        moveinput.Normalize();
        if (moveinput.sqrMagnitude > 0.5)
        {
            if (ReadyToMove)
            {
                ReadyToMove = false;
                Move(moveinput);
            }
        }
        else
        {
            ReadyToMove = true;
            isMoving = false;
        }
    }
    public bool Move(Vector2 direction)
    {
        if (Mathf.Abs(direction.x) > 0.5)
        {
            direction.y = 0;
        }
        else if (Mathf.Abs(direction.y) > 0.5)
        {
            direction.x = 0;
        }
        
        direction.Normalize();

        if (Blocked(transform.position, direction))
        {
            return false;
        }
        
        else
        {
            SoundManager.instance.PlayPlayerMoveSound();
            transform.Translate(direction);
            isMoving = true;
            lastMoveDirection = direction;
            return true;
        }
        

    }
    public bool Blocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;
        RaycastHit2D wallHit = Physics2D.Raycast(position, direction, rayLength, wallLayer);
        
        foreach (var obstacles in Obstacles)
        {
            if ((obstacles.transform.position.x == newPos.x) && (obstacles.transform.position.y == newPos.y))
            {
                return true;
            }
        }

        foreach (var objToPush in ObjToPush)
        {
            if ((objToPush.transform.position.x == newPos.x) && (objToPush.transform.position.y == newPos.y))
            {
                Push objpush = objToPush.GetComponent<Push>();
                if ((objpush) && (objpush.Move(direction)))
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
        if (wallHit.collider != null)
        {
            Debug.Log("Hit wall: " + wallHit.collider.name);
            SoundManager.instance.PlayWallHit();
            return true;
        }
        return false;

    }
    public void OnEnterCollision2D(Collision collision)
    {
        if ((collision.gameObject.CompareTag("Walls")||(collision.gameObject.CompareTag("ObjToPush"))))
        {
            Debug.Log("Collided with Wall");
        }
    }
}
