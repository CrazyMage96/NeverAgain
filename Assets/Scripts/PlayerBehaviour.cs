using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
[RequireComponent (typeof (Animator))]
public class PlayerBehaviour : MonoBehaviour {

	private string FORWARD_AXIS = "Vertical";
	private string SIDEWAYS_AXIS = "Horizontal";
	public float runVelocity = 12;

	private Rigidbody playerRigidbody;
	private Animator animator;
	private Vector3 velocity;
	private float forwardInput, sidewaysInput;

	void Awake () 
	{
		velocity = Vector3.zero;
		forwardInput = sidewaysInput = 0;
		playerRigidbody = gameObject.GetComponent<Rigidbody>();
		animator = gameObject.GetComponent<Animator>();
	}
	

	void Update () 
	{
		GetInput ();
		if (transform.position.y < -10) {
			Application.LoadLevel ("GameOver");
		}
	}

	void FixedUpdate()
	{
		Run ();
	}
	void GetInput()
	{
		if (FORWARD_AXIS.Length != 0) {
			forwardInput = Input.GetAxis (FORWARD_AXIS);
		}
		if (SIDEWAYS_AXIS.Length != 0) {
			sidewaysInput = Input.GetAxis (SIDEWAYS_AXIS);
		}
	}
	void Run()
	{
		if (forwardInput != 0 || sidewaysInput != 0) {
			animator.SetBool ("walk", true);
		} else {
			animator.SetBool ("walk", false);
		}
		velocity.z = forwardInput * runVelocity;
		velocity.x = sidewaysInput * runVelocity;
		velocity.y = playerRigidbody.velocity.y;
		playerRigidbody.velocity = velocity; //Bewegung des Spielers wird direkt auf die globale Koordinate übergeben

		if (forwardInput < 0)
		{
			transform.rotation = Quaternion.AngleAxis(-180, Vector3.up);
		}
		else if (forwardInput > 0) 
		{ 
			transform.rotation = Quaternion.AngleAxis(0, Vector3.up); 
		}
		if (sidewaysInput < 0)
		{
			transform.rotation = Quaternion.AngleAxis(-90, Vector3.up);
		}
		else if (sidewaysInput > 0)
		{
			transform.rotation = Quaternion.AngleAxis(90,Vector3.up);
			
		}

	}
	void OnCollisionEnter(Collision collision){
		//Debug.Log ("We hit: " + collision.gameObject.name);
		if (collision.gameObject.tag == "Enemy" || collision.gameObject.tag == "Ghost")
			Application.LoadLevel ("GameOver");
	}
}

