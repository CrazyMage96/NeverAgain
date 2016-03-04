using UnityEngine;
using System.Collections;

public class PickUp : MonoBehaviour {

	// Use this for initialization
	//private Rigidbody player;
	public GameObject  controller;
	//private int x = 2;
	
	// Update is called once per frame
    void Start()
    {
        controller = GameObject.FindGameObjectWithTag("GameController");
    }
	void OnTriggerEnter (Collider collision){
		Controler script = controller.GetComponent<Controler> ();
		Debug.Log("Collision detected");
		if (collision.gameObject.tag == "Player"&& script.cooldown < 2) {
			Debug.Log("Player hits PickUp");
		



			script.cooldown = 3;

			Destroy(gameObject);
		}


}
}
