using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using AutoChessTD.Units.Minions;

public class PlayerController : MonoBehaviour
{

    public NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetDestination(Vector3 destination)
    {
        agent.SetDestination(destination);
    }
}
