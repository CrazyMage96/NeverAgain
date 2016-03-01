using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody))]
public class PlayerBehaviour : MonoBehaviour {

	[System.Serializable]
	public class MoveSettings 
	{
		public float runVelocity = 12;
		public float rotateVelocity = 100;
	}

	[System.Serializable]
	public class InputSettings 
	{
		public string FORWARD_AXIS = "Vertical";
		public string SIDEWAYS_AXIS = "Horizontal";
	}
	public MoveSettings moveSettings;
	public InputSettings inputSettings;

	private Rigidbody playerRigidbody;
	private Vector3 velocity;
	private float forwardInput, sidewaysInput;

	void Awake () 
	{
		velocity = Vector3.zero;
		forwardInput = sidewaysInput = 0;
		playerRigidbody = gameObject.GetComponent<Rigidbody>();
	}
	

	void Update () 
	{
		GetInput ();
	}

	void FixedUpdate()
	{
		Run ();
	}
	void GetInput()
	{
		if (inputSettings.FORWARD_AXIS.Length != 0)
		{
			forwardInput = Input.GetAxis(inputSettings.FORWARD_AXIS);
		}
		if (inputSettings.SIDEWAYS_AXIS.Length != 0)
		{
			sidewaysInput = Input.GetAxis(inputSettings.SIDEWAYS_AXIS);
		}
	}
	void Run()
	{
		velocity.z = forwardInput * moveSettings.runVelocity;
		velocity.x = sidewaysInput * moveSettings.runVelocity;
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
}
