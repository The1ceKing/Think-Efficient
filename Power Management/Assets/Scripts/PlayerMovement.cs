using System.Collections;
using System.Collections.Generic;
using System.Numerics;
using UnityEngine;
using UnityEngine.AI;
using Vector3 = UnityEngine.Vector3;

public class PlayerMovement : MonoBehaviour
{
    public Transform destination;
    private NavMeshAgent Agent;
    public List<Transform> stuff = new List<Transform>();

    public GameObject player;

    void Start()
    {
        // Referencing the NavMeshAgent
         Agent = GetComponent<NavMeshAgent>();
        
        player = GameObject.Find("Player");
    
        // Add all GameObjects I need to a List to be call on later 
        //stuff.AddRange(GameObject.FindGameObjectsWithTag("Stuff"));
        
        // Find a random item from List and set it as its destination
        destination.position = stuff[Random.Range(0, stuff.Count)].transform.position;
        
        Agent.destination = destination.position;
        
    }

    enum walkstate
    {
        empty,
        pathing,
        reached
    }

    walkstate ws = walkstate.empty;
    float timeout;

    void Update()
    {
        if (ws == walkstate.empty)
        {
            destination = stuff[Random.Range(0, stuff.Count)].transform;
            Agent.SetDestination(destination.position);
            timeout = Random.Range(6, 24);
            ws = walkstate.pathing;
        } else if (ws != walkstate.reached)
        {
            if ((player.transform.position - destination.position).sqrMagnitude <= 1)
            {
                StartCoroutine(Idler());
                ws = walkstate.reached;
            }
        }

        timeout -= Time.deltaTime;
        if (timeout <= 0) {
            ws = walkstate.reached;
        }
    }

    IEnumerator Idler() {
        yield return new WaitForSeconds(Random.Range(0.5f, 4));
        ws = walkstate.empty;
    }
}
