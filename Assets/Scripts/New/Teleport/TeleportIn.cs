using UnityEngine;

public class TeleportIn : MonoBehaviour
{
    [SerializeField] Teleport teleport;
    public bool isTeleportInOccupied;
    [SerializeField] private TeleportOut teleportOut;
    public Animator anim;
    private void Start()
    {
        teleport = FindAnyObjectByType<Teleport>();
        teleportOut = FindAnyObjectByType<TeleportOut>();
        anim = GetComponent<Animator>();
        anim.Play("TeleportIdle");
    }
    private void OnTriggerEnter2D(Collider2D collidedWith)
    {
        isTeleportInOccupied = true;
      // Debug.Log("TriggerEnter with " + collidedWith.gameObject.tag);
        if (((collidedWith.CompareTag("Player") || collidedWith.CompareTag("ObjToPush")) && !(teleport.isTeleportCoolingNow) && !(teleportOut.isTeleportOutOccupied)))
        {
            StartCoroutine(teleport.TeleportationToOut(collidedWith.gameObject));
        }
    }
    private void OnTriggerExit2D(Collider2D collidedWith)
    {          
        anim.Play("TeleportIdle");
        isTeleportInOccupied = false;
    }
}
