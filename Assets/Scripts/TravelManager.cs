using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
    // All the route points, added from inspector
    public List<GameObject> travelNodesObjects;
    public float speed = 3;

    // For moving state managment
    private string currentNode = "";
    private string originNode = "";
    private string goalNode = "";
    private bool moving = false;

    // Direction references
    private Transform characterTransform;
    private Vector2 direction = Vector2.zero;
    private Vector2 pressedDirection = Vector2.zero;

    // Reference the neighbors of each of the nodes
    private Dictionary<string, List<string>> travelNeighborsMap = new Dictionary<string, List<string>>();

    // All nodes positions
    private Dictionary<string, Vector2> travelNodes = new Dictionary<string, Vector2>();

    // Start is called before the first frame update
    void Start()
    {
        characterTransform = gameObject.transform;
        currentNode = travelNodesObjects[0].gameObject.name;

        // Go to each node and save its neighbors in the list
        for (int i = 0; i < travelNodesObjects.Count; i++)
        {
            GameObject go = travelNodesObjects[i];
            List<GameObject> neighborNodes = go.GetComponent<TravelNode>().neighborNodes;
            List<string> neighborNames = neighborNodes.ConvertAll(new System.Converter<GameObject, string>(go => go.gameObject.name));
            travelNeighborsMap.Add(go.gameObject.name, neighborNames);
        }

        // Saving all node positions
        for (int i = 0; i < travelNodesObjects.Count; i++)
        {
            GameObject go = travelNodesObjects[i];
            travelNodes.Add(go.gameObject.name, (Vector2)go.gameObject.transform.position);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Keyboard directions (arrows, wasd)
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // Some direction pressed
        if (v != 0 || h != 0)
        {
            // If is already moving, applies another step
            if (moving)
            {
                Vector2 charPos = (Vector2) characterTransform.position;
                Vector2 vec = travelNodes[goalNode] - charPos;

                // If is still moving and changes the direction about the goalNode, meaning that was surpassed, character reached goal
                if (direction != vec.normalized)
                {
                    characterTransform.position += ((Vector3)direction * speed * Time.deltaTime);
                    moving = false;
                    currentNode = goalNode;
                    return;
                }

                characterTransform.position += ((Vector3)direction * speed * Time.deltaTime);
            }
            // If not moving find a posible node to move to
            else
            {
                List<string> neighbors = travelNeighborsMap[currentNode];
                pressedDirection.x = h;
                pressedDirection.y = v;

                for (int i = 0; i < neighbors.Count; i++)
                {
                    Vector2 posibleDirection = travelNodes[neighbors[i]] - ((Vector2)characterTransform.position);

                    // Evaluates if angle of the direction pressed is close enough to node route direction 
                    if (Mathf.Abs(Vector2.Angle(pressedDirection, posibleDirection)) <= 45.0f)
                    {
                        direction = posibleDirection;
                        direction = direction.normalized;
                        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                        sr.flipX = direction.x < 0;
                        originNode = currentNode;
                        goalNode = neighbors[i];
                        moving = true;
                        return;
                    }
                }
            }
        }
        else
            moving = false;
    }
}