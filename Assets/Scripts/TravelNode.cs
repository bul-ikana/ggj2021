using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TravelNode : MonoBehaviour
{
    // Immediate nodes, added from inspector
    public List<GameObject> neighborNodes;
    public UnityEvent triggerGoal;

    // Start is called before the first frame update
    void Start()
    {
        // goal_function = TriggerGoal;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void TriggerGoal ()
    {
        triggerGoal.Invoke();
    }
}
