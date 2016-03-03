using UnityEngine;
using System.Collections;

public class MovingPlattforms : MonoBehaviour{

	private Vector3 move;
	private Vector3 startPosition;
	
	public float moveSpeed;
	public float range;
	public bool xAxis;
	public bool yAxis;
	public bool zAxis;

	// Use this for initialization
	void Start () {
		int random = 0;
		while (random == 0) {
			random = (int)Random.Range (-1f, 1f);
		}
		if (xAxis) {
			move = Vector3.right * Time.deltaTime*moveSpeed*random;
		} else if (yAxis) {
			move = Vector3.up * Time.deltaTime*moveSpeed*random;
		} else if (zAxis) {
			move = Vector3.forward * Time.deltaTime*moveSpeed*random;
		}
		startPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (xAxis) {
			move = MoveVector(startPosition.x, transform.position.x, Vector3.right);
		} else if (yAxis) {
			move = MoveVector(startPosition.y, transform.position.y, Vector3.up);
		} else if (zAxis) {
			move = MoveVector(startPosition.z, transform.position.z, Vector3.forward);
		}
		transform.position += move;
	}

	private Vector3 MoveVector(float center, float position, Vector3 direction){
		if (position > center + range) {
			moveSpeed *= -1;
		} else if (position < center - range) {
			moveSpeed *= -1;
		}
		return direction * Time.deltaTime * moveSpeed;
	}
}
