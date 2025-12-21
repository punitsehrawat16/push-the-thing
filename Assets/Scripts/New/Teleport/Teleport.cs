using System.Collections;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    [Header("Teleport General")]
    public bool isTeleportCoolingNow;
    [SerializeField] private float teleportCooldownTime = 3f;

    [Header("Teleport Platforms")]
    [SerializeField] GameObject TeleportIn;
    [SerializeField] GameObject TeleportOut;
    [SerializeField]TeleportIn teleportIn;
    [SerializeField]TeleportOut teleportOut;

    [Header("Player")]
    [SerializeField] GameObject player;
    [SerializeField] Rigidbody2D prb;
    [SerializeField] PlayerMovement pm;
    [SerializeField] PlayerAnimation pa;

    [Header("Teleport Ui Icon")]
    [SerializeField] GameObject TeleportAvailable;
    [SerializeField] GameObject TeleportNotAvailable;

    private void Start()
    {
        TeleportIn = GameObject.FindGameObjectWithTag("TeleportIn");
        TeleportOut = GameObject.FindGameObjectWithTag("TeleportOut");
        teleportIn = TeleportIn.GetComponent<TeleportIn>();
        teleportOut = TeleportOut.GetComponent<TeleportOut>();

        player = GameObject.FindGameObjectWithTag("Player");
        pm = player.GetComponent<PlayerMovement>();
        pa = player.GetComponent<PlayerAnimation>();
        prb = player.GetComponent<Rigidbody2D>();

        TeleportAvailable.SetActive(true);
        TeleportNotAvailable.SetActive(false);
    }

    public Vector3 GetTransformPositionOfIn()
    {
        return TeleportIn.transform.position;
    }
    public Vector3 GetTransformPositionOfOut()
    {
        return TeleportOut.transform.position;
    }
    public IEnumerator TeleportationToOut(GameObject obj)
    {
        TeleportAvailable.SetActive(false);
        TeleportNotAvailable.SetActive(true);
        isTeleportCoolingNow = true;
        if (obj == player.gameObject)
        {

            SoundManager.instance.PlayTeleportSound();
            pa.PlayTeleportAnimation();
            yield return new WaitForSeconds(.5f);
            teleportOut.anim.Play("TeleportAnim");

            obj.transform.position = GetTransformPositionOfOut();
            pa.PlayTeleportOutAnimation();
            yield return new WaitForSeconds(.5f);
            pa.EndTeleport();
        }
        else
        {
            SoundManager.instance.PlayTeleportSound();
            obj.GetComponent<BoxAnimation>().PlayBoxTeleportIn();
            yield return new WaitForSeconds(.5f);
            teleportOut.anim.Play("TeleportAnim");

            obj.transform.position = GetTransformPositionOfOut();
            obj.GetComponent<BoxAnimation>().PlayBoxTeleportOut();
            yield return new WaitForSeconds(.5f);
            obj.GetComponent<BoxAnimation>().StopTeleporting();
        }

        Debug.Log("Teleport on CoolDown for " + teleportCooldownTime + " seconds");
        yield return new WaitForSeconds(teleportCooldownTime);
        isTeleportCoolingNow = false;
        Debug.Log("Teleport is available");
        TeleportAvailable.SetActive(true);
        TeleportNotAvailable.SetActive(false);

    }
    public IEnumerator TeleportationToIn(GameObject obj)
    {
        TeleportAvailable.SetActive(false);
        TeleportNotAvailable.SetActive(true);
        isTeleportCoolingNow = true;
        if (obj == player.gameObject)
        {
            SoundManager.instance.PlayTeleportSound();
            pa.PlayTeleportAnimation();
            yield return new WaitForSeconds(.5f);

            teleportIn.anim.Play("TeleportAnim");
            obj.transform.position = GetTransformPositionOfIn();
            pa.PlayTeleportOutAnimation();
            yield return new WaitForSeconds(0.5f);
            pa.EndTeleport();
        }
        else
        {
            SoundManager.instance.PlayTeleportSound();
            obj.GetComponent<BoxAnimation>().PlayBoxTeleportIn();
            yield return new WaitForSeconds(.5f);
            teleportIn.anim.Play("TeleportAnim");

            obj.transform.position = GetTransformPositionOfIn();
            obj.GetComponent<BoxAnimation>().PlayBoxTeleportOut();
            yield return new WaitForSeconds(.5f);
            obj.GetComponent<BoxAnimation>().StopTeleporting();
        }
        Debug.Log("Teleport on CoolDown for " + teleportCooldownTime + " seconds");
        yield return new WaitForSeconds(teleportCooldownTime);
        isTeleportCoolingNow = false;
        Debug.Log("Teleport is available");
        TeleportAvailable.SetActive(true);
        TeleportNotAvailable.SetActive(false);
    }
}
