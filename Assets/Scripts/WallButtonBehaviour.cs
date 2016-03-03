using UnityEngine;
using System.Collections;

public class WallButtonBehaviour : MonoBehaviour {

	private Renderer rend;
	private Collider coll;
	public GameObject wall;
	private NavMeshObstacle obst;
	
	//public float time = 2f;
	// Use this for initialization
	void Start () {
		rend = wall.GetComponent<Renderer>();
		coll = wall.GetComponent<Collider>();
		obst = wall.GetComponent<NavMeshObstacle> ();
		//StartCoroutine (blinken(time));
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision otherObject)
	{
		if(otherObject.gameObject.tag == "Player")
		{
			coll.enabled = false;
			rend.enabled = false;
			obst.enabled = false;
			gameObject.GetComponent<Renderer>().enabled = false;
			gameObject.GetComponent<Collider>().enabled = false;
		}
	}

	//IEnumerator blinken(float ptime)
}
