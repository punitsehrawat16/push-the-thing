using UnityEngine;

public class GoalDetector : MonoBehaviour
{
    
    [SerializeField] int correctBoxplaced = 0;
    public FinalPosition fp;
    private void Start()
    {
       
        fp = FindAnyObjectByType<FinalPosition>();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjToPush"))
        {
            Debug.Log("Box Placed on Target");
            fp.BoxPlaced();
        }
;
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("ObjToPush"))
        {
            Debug.Log("Box Removed from Target");
            fp.BoxRemoved();
        }
;
    }
    
    
}
