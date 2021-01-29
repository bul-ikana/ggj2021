using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class attractCharacter : MonoBehaviour
{
    public GameObject character;   
    public float speed = 10;
    
    private Transform charTransform;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
	    charTransform = character.transform;
        direction = Vector3.zero;
    }

    // Update is called once per frame
    void Update()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");
        if (direction == Vector3.zero)
            return;

    	charTransform.position += direction * speed * Time.deltaTime;
        Vector3 vec = gameObject.transform.position - (charTransform.position + direction * speed * Time.deltaTime);
        if (vec.normalized != direction)
            direction = Vector3.zero;
    }

    void OnMouseDown()
    {
        direction = gameObject.transform.position - charTransform.position;
        direction = direction.normalized;
        SpriteRenderer sr = character.gameObject.GetComponent<SpriteRenderer>();
        sr.flipX = direction.x < 0;
    }
}
