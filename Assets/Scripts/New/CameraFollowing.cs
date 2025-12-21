using UnityEngine;
using System.Collections;

public class CameraFollowing : MonoBehaviour
{
    [Header("Cam Switch")]
    [SerializeField] Camera cam;
    [SerializeField] float[] camSizes = {3.2f,5f,6.8f};
    int camSizesIndex = 0;

    [Header("Player Follow")]
    [SerializeField] Transform playerTransform;
    [SerializeField] Vector3 offset;
    [SerializeField] float smoothMovingSpeed = 0.05f;
    //Vector3 velocity = Vector3.zero;
    public void Start()
    {
        playerTransform = FindObjectOfType<PlayerMovement>().transform;
        cam = FindAnyObjectByType<Camera>();
        camSizes[1] = cam.orthographicSize;
    }
    public void FixedUpdate()
    {
        Vector3 desiredPosition = playerTransform.position + offset;
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothMovingSpeed);
        // Vector3 smoothedPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothMovingSpeed);
        transform.position = smoothedPosition;
    }
    public void CamSetting()
    {
        camSizesIndex++;
        if (camSizesIndex > camSizes.Length)
        {
            camSizesIndex = 0;
        }
        cam.orthographicSize = camSizes[camSizesIndex];
        Debug.Log("Cam size : " + cam.orthographicSize);
    }
}
