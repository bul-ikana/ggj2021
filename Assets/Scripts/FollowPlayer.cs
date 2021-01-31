using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float leftLimit = 0.0f;
    public float rightLimit = 0.0f;
    public float topLimit = 0.0f;
    public float bottomLimit = 0.0f;

    public GameObject player;

    private Transform playerTransform;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = new Vector3(Mathf.Max(Mathf.Min(playerTransform.position.x, rightLimit), leftLimit),
            Mathf.Max(Mathf.Min(playerTransform.position.y, topLimit), bottomLimit), 
            gameObject.transform.position.z);
    }
}
