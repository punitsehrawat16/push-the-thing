using UnityEngine;

public class TeleportOut : MonoBehaviour
{
    [SerializeField] Teleport teleport;
    public bool isTeleportOutOccupied;
    [SerializeField] TeleportIn teleportIn;
    public Animator anim;
    private void Awake()
    {
        teleport = FindAnyObjectByType<Teleport>();
        teleportIn = FindAnyObjectByType<TeleportIn>();
        anim = GetComponent<Animator>();
        anim.Play("TeleportIdle");
    }
    private void OnTriggerEnter2D(Collider2D collidedWith)
    {
        isTeleportOutOccupied = true;
       // Debug.Log("TriggerEnter with " + collidedWith.gameObject.tag);
        if (((collidedWith.CompareTag("Player") || collidedWith.CompareTag("ObjToPush")) && !(teleport.isTeleportCoolingNow) && !(teleportIn.isTeleportInOccupied)))
        {
            StartCoroutine(teleport.TeleportationToIn(collidedWith.gameObject));
        }
    }
    private void OnTriggerExit2D(Collider2D collidedWith)
    {
        anim.Play("TeleportIdle");
        isTeleportOutOccupied = false;
    }
}
