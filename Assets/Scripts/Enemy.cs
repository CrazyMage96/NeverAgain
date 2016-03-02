using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {

	public Transform goal;
	
	void Update () {
		NavMeshAgent agent = GetComponent<NavMeshAgent>();
		agent.destination = goal.position; 
	}
}
