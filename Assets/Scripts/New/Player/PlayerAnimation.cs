using System.Collections;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    PlayerMovement playermovement;
    Animator anim;
    Teleport teleport;
    bool isTeleporting = false;
    void Start()
    {
        anim = GetComponent<Animator>();
        playermovement = GetComponent<PlayerMovement>();
        teleport = FindAnyObjectByType<Teleport>().GetComponent<Teleport>();
    }

    void Update()
    {
        if (isTeleporting)return;
        bool isMoving = playermovement.isMoving;
        Vector2 direction = playermovement.lastMoveDirection;
        if (isMoving)
        {
            if ((direction.x) > 0.5)
            {
                anim.Play("PlayerWalkRight");
            }
            else if ((direction.x) < -0.5)
            {
                anim.Play("PlayerWalkLeft");
            }
            else if ((direction.y) > 0.5)
            {
                anim.Play("PlayerWalkUp");
            }
            else if ((direction.y) < -0.5)
            {
                anim.Play("PlayerWalkDown");
            }
        }
        
        else
        {
            if ((direction.x) > 0.5)
            {
                anim.Play("PlayerIdleRight");
            }
            else if ((direction.x) < -0.5)
            {
                anim.Play("PlayerIdleLeft");
            }
            else if ((direction.y) > 0.5)
            {
                anim.Play("PlayerIdleUp");
            }
            else if ((direction.y) < -0.5)
            {
                anim.Play("PlayerIdleDown");
            }
        }
        }
    
    public void PlayTeleportAnimation()
    {
        isTeleporting = true;
        anim.SetTrigger("TeleportIn");
    }
    public void PlayTeleportOutAnimation()
    {
        isTeleporting = true;
        anim.SetTrigger("TeleportOut");
    }
    public void EndTeleport()
    {
        isTeleporting = false;
    }
}


