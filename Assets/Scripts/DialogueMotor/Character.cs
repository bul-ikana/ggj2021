using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private float smoothTime        =   0.3F;
    private Vector3 velocity        =   Vector3.zero;
    private Vector3 targetPosition  =   Vector3.zero;

    void Start()
    {
        targetPosition = transform.position;
    }

    void Update()
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
    }

    public void Highlight()
    {
        targetPosition = transform.TransformPoint(new Vector3(0, 1, 0));
    }

    public void Deemphasize()
    {
        targetPosition = transform.TransformPoint(new Vector3(0, -1, 0));
    }
}
