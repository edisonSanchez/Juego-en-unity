using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform target;
    public Transform leftBound, rightBound;
    private float leftBoundsWidth, rightBoundsWidth;

    public float smoothDampTime = 0.15f;
    private Vector3 smoothDampVelocity = Vector3.zero;
    private float camWidth, camHeight, levelMinX, levelMaxX;

    // Start is called before the first frame update
    void Start()
    {
        camHeight = Camera.main.orthographicSize * 2;
        camWidth = camHeight * Camera.main.aspect;

        leftBoundsWidth = leftBound.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;
        rightBoundsWidth = rightBound.GetComponentInChildren<SpriteRenderer>().bounds.size.x / 2;

        levelMinX = leftBound.position.x + leftBoundsWidth + (camWidth / 2);
        levelMaxX = rightBound.position.x - rightBoundsWidth - (camWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        float targetX = Mathf.Max(levelMinX, Mathf.Min(levelMaxX, target.position.x));
        float x = Mathf.SmoothDamp(transform.position.x, targetX, ref smoothDampVelocity.x, smoothDampTime);
        transform.position = new Vector3(x, transform.position.y, transform.position.z);
    }
}
