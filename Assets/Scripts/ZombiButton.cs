using UnityEngine;
using System.Collections;

public class ZombiButton : MonoBehaviour {
	private Renderer renderer;
	private Collider collider;
	private NavMeshObstacle nav;
	private GameObject[] spawnedZombies;

	// Use this for initialization
	void Start () {
		renderer = gameObject.GetComponent<Renderer>();
		collider = gameObject.GetComponent<Collider> ();
		nav = gameObject.GetComponent<NavMeshObstacle>();

		/*int random = (int)Random.Range (0f, 3f);
		if (random != 0) {
			renderer.enabled = false;
			collider.enabled = false;
			nav.enabled = false;
		}*/
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter(Collision otherObject)
	{
		if(otherObject.gameObject.tag == "Player")
		{
			collider.enabled = false;
			renderer.enabled = false;
			nav.enabled = false;

			spawnedZombies = GameObject.FindGameObjectsWithTag("Enemy");
			foreach(GameObject zombi in spawnedZombies){
				Destroy(zombi);
			}
		}
	}
}
