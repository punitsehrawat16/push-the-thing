using UnityEngine;

public class Push : MonoBehaviour
{
    GameObject[] ObjToPush;
    GameObject[] Obstacles;
    [SerializeField] LayerMask layer;
    void Start()
    {
        ObjToPush = GameObject.FindGameObjectsWithTag("ObjToPush");
        Obstacles = GameObject.FindGameObjectsWithTag("Obstacle");
    }

    
    public bool Move(Vector2 direction)
    {
        if (ObjToBlocked(transform.position, direction))
        {
            return false;
        }
        else
        {
            SoundManager.instance.PlayBoxPushSound();
            transform.Translate(direction);
            return true;
        }
    }
    public bool ObjToBlocked(Vector3 position, Vector2 direction)
    {
        Vector2 newPos = new Vector2(position.x, position.y) + direction;

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
                return true;
            }
        }
        RaycastHit2D checkWall= Physics2D.Raycast(position, direction, 1f, layer);
        if (checkWall.collider != null)
        {
            Debug.Log("Box Hit Wall");
            SoundManager.instance.PlayWallHit();
            return true;
        }
        return false;
    }
}
