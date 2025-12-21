using UnityEngine;

public class BoxAnimation : MonoBehaviour
{
    Animator anim;
    bool isTeleporting = false;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        anim = GetComponent<Animator>();

        anim.Play("BoxIdle");
    }

    // Update is called once per frame
    void Update()
    {
        if (isTeleporting) return;
    }
    public void PlayBoxTeleportIn()
    {
        isTeleporting = true;
        anim.Play("BoxTeleportIn");
    }
    public void PlayBoxTeleportOut()
    {
        isTeleporting = true;
        anim.Play("BoxTeleportOut");
    }
    public void StopTeleporting()
    {
        isTeleporting = false;
        anim.Play("BoxIdle");
    }
}

