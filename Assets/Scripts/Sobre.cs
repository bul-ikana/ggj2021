using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sobre : MonoBehaviour
{

    private int direction = -1;
    private float floatTime  = 2f;
    private float elapsedTime  = 0f;
    private float smoothTime = 0.8F;
    private Vector3 velocity = Vector3.zero;

    void Update()
    {
        elapsedTime += Time.deltaTime;
        if (elapsedTime >= floatTime) {
            elapsedTime = elapsedTime % floatTime;
            direction = -direction;
        } else {
            Vector3 targetPosition = transform.TransformPoint(new Vector3(0, 0.1f * direction, 0));

            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }
}
