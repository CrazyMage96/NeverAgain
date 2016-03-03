using UnityEngine;
using System.Collections;


public class NewBehaviourScript : MonoBehaviour {

	// Use this for initialization
	public float speed;
   Rigidbody wall;
	void Start () {
		wall = gameObject.GetComponent<Rigidbody>();
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		wall.velocity = new Vector3 (0, wall.velocity.y, speed );
	}
	void OnCollisionEnter(Collision collision){
		if(collision.gameObject.tag=="EndTag"){
			speed *=-1;


}
}
}
