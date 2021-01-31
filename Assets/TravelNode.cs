using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelNode : MonoBehaviour
{
    public List<GameObject> neighborNodes;

    private List<Vector3> neighborNodesPositions;

    // Start is called before the first frame update
    void Start()
    {
        neighborNodesPositions = neighborNodes.ConvertAll(new System.Converter<GameObject, Vector3>(toPosition));
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private Vector3 toPosition(GameObject go)
    {
        return go.gameObject.transform.position;
    }
}
