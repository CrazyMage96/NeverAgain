using UnityEngine;
using System.Collections;

public class WallBehaviour : MonoBehaviour {

	private Renderer rend;
	private Collider coll;
	private NavMeshObstacle obst;

	public float time = 2f;
	// Use this for initialization
	void Start () {
		rend = gameObject.GetComponent<Renderer>();
		coll = gameObject.GetComponent<Collider> ();
		obst = gameObject.GetComponent<NavMeshObstacle> ();
		StartCoroutine (blinken(time));
	
	}
	
	// Update is called once per frame
	void Update () {

	
	}

	IEnumerator blinken(float ptime)
	{
		while (true) {
			yield return new WaitForSeconds (ptime);
			//gameObject.enabled = false;
			coll.enabled = false;
			rend.enabled = false;
			obst.enabled = false;
			yield return new WaitForSeconds (ptime);
			coll.enabled = true;
			rend.enabled = true;
			obst.enabled = true;
		}
	}

}
