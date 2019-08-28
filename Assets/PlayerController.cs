using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        agent.SetDestination(new Vector3(12, 1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
