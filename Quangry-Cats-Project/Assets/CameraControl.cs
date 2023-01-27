using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    [SerializeField]
    protected Transform trackingTarget;

    [SerializeField]
    protected float followSpeed;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    [SerializeField]
    float zoomSpeed = 5.0f;


    private float originalSize = 0f;

    private Camera thisCamera;

    // Use this for initialization
    void Start()
    {
        thisCamera = GetComponent<Camera>();
        originalSize = thisCamera.orthographicSize;
    }

    protected void Update()
    {
        float xTarget = trackingTarget.position.x + xOffset;
        float yTarget = trackingTarget.position.y + yOffset;

        float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
        float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

        transform.position = new Vector3(xNew, yNew, transform.position.z);

        float xsize = Mathf.Abs(trackingTarget.position.x) / 12f;

        float ysize = Mathf.Abs(trackingTarget.position.y) / 15f;
        float zoomsize = 5f*Mathf.Max(xsize, ysize, 1f);

        thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, zoomsize, Time.deltaTime * zoomSpeed);
    }
}
