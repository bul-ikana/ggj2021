using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TravelManager : MonoBehaviour
{
    // All the route points, added from inspector
    public List<GameObject> travelNodesObjects;
    public float speed = 3.0f;

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
    
    // All node nodes (lol)
    private Dictionary<string, TravelNode> nodeNodes = new Dictionary<string, TravelNode>();

    private Animator animator;

    // For controlled pauses in Update
    private float pauseDuration = 0;

    // Start is called before the first frame update
    void Start()
    {
        characterTransform = gameObject.transform;
        animator = gameObject.GetComponent<Animator>();
        //currentNode = travelNodesObjects[0].gameObject.name;
        //originNode = currentNode;
        //goalNode = currentNode;

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

        for (int i = 0; i < travelNodesObjects.Count; i++)
        {
            GameObject go = travelNodesObjects[i];
            nodeNodes.Add(go.gameObject.name, go.GetComponent<TravelNode>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (pauseDuration > 0.0f)
        {
            pauseDuration -= Time.deltaTime;
            return;
        }

        // Keyboard directions (arrows, wasd)
        float v = Input.GetAxis("Vertical");
        float h = Input.GetAxis("Horizontal");

        // Some direction pressed
        if (v != 0 || h != 0)
        {
            // If is already moving, applies another step
            if (moving/* && pressedDirection.y == v && pressedDirection.x == h*/)
            {
                //Vector2 charPos = (Vector2)characterTransform.position;
                //Vector2 vec = travelNodes[goalNode] - charPos;

                // If is still moving and changes the direction about the goalNode, meaning that was surpassed, character reached goal

                //if (vec.magnitude <= 0.2f)
                //{
                    //moving = false;
                    //currentNode = goalNode;
                    //originNode = goalNode;
                    //pauseDuration = 0.2f;

                    //return;
                //}


                characterTransform.position += ((Vector3)direction * speed * Time.deltaTime);
            }
            // If not moving find a posible node to move to
            else
            {
                pressedDirection.x = h;
                pressedDirection.y = v;
                List<string> neighbors;

                if (currentNode != "")
                    neighbors = travelNeighborsMap[currentNode];
                else
                {
                    neighbors = new List<string>();
                    neighbors.Add(originNode);
                    neighbors.Add(goalNode);
                }

                for (int i = 0; i < neighbors.Count; i++)
                {
                    Vector2 posibleDirection = travelNodes[neighbors[i]] - ((Vector2)characterTransform.position);

                    // Evaluates if angle of the direction pressed is close enough to node route direction 
                    if (Mathf.Abs(Vector2.Angle(pressedDirection, posibleDirection)) <= 45.0f || posibleDirection.magnitude < 0.6f)
                    {
                        direction = posibleDirection;
                        direction = direction.normalized;
                        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();
                        sr.flipX = direction.x < 0;
                        //if (currentNode != "")
                        //    originNode = currentNode;
                        if (neighbors[i] == originNode)
                            //{
                            //    //currentNode = goalNode;
                            originNode = goalNode;
                        //}
                        //else
                        //    originNode = currentNode;

                        goalNode = neighbors[i];
                        moving = true;
                        animator.CrossFade("JulioWalking", 0.0f);
                        return;
                    }
                }
            }
        }
        else
        {
            moving = false;
            animator.CrossFade("JulioIdle", 0.0f);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log(gameObject.name + " recived a hit from " + collision.gameObject.name);
        currentNode = collision.gameObject.name;
        pauseDuration = 0.05f;
        moving = false;
        nodeNodes[currentNode].TriggerGoal();

        // Special exceptions for z coordinate
        if (currentNode == "Node (1)" || currentNode == "Node (5)")
            characterTransform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, 0);
        else if (currentNode == "Node (2)" || currentNode == "Node (10)")
            characterTransform.position = new Vector3(characterTransform.position.x, characterTransform.position.y, -3);
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        //Debug.Log(gameObject.name + " left " + collision.gameObject.name);
        //if (collision.gameObject.name == current)
        originNode = collision.gameObject.name;
        currentNode = "";
    }
}