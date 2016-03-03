using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

    public int platformID=0;
    private Transform goal;

    void Start()
    {
        goal = GameObject.FindGameObjectWithTag("Player").transform;
    }

	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}
}
