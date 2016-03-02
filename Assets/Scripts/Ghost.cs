using UnityEngine;
using System.Collections;

public class Ghost : MonoBehaviour {
    public float speed;
    public GameObject player;

	// Update is called once per frame
	void Update () {
        transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed*Time.deltaTime);
    }
}
