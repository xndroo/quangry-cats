using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public static Transform trackingTarget = null;

    [SerializeField]
    protected float followSpeed;

    [SerializeField]
    float xOffset;

    [SerializeField]
    float yOffset;

    [SerializeField]
    float zoomSpeed = 5.0f;

    [SerializeField]
    float minZoom = 5.0f;


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
        if (!(trackingTarget==null))
        {
            float xTarget = trackingTarget.position.x + xOffset;
            float yTarget = trackingTarget.position.y + yOffset;

            float xNew = Mathf.Lerp(transform.position.x, xTarget, Time.deltaTime * followSpeed);
            float yNew = Mathf.Lerp(transform.position.y, yTarget, Time.deltaTime * followSpeed);

            transform.position = new Vector3(xNew, yNew, transform.position.z);

            float xsize = Mathf.Abs(trackingTarget.position.x) * 5f/11.25f;

            float ysize = Mathf.Abs(trackingTarget.position.y);
            float zoomsize = Mathf.Max(xsize, ysize, minZoom);

            thisCamera.orthographicSize = Mathf.Lerp(thisCamera.orthographicSize, zoomsize, Time.deltaTime * zoomSpeed);
        }
    }
}
