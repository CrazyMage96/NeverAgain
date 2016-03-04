using UnityEngine;
using System.Collections;

public class TimerForEnd : MonoBehaviour {
	private bool once=true;
	public float timeLimit;
	public GameObject playTheme;
	void Start () {
	}
	void Update () {
		if (timeLimit > 1)
			
		{
			timeLimit -= Time.deltaTime;
			transform.Translate(Vector3.back * Time.deltaTime, Space.World);
			Debug.Log(timeLimit);
		}
		else if (timeLimit < 1) {
			if(once)
			{
				GameObject placeHolder = playTheme;
				GameObject good = (GameObject)Instantiate(placeHolder, transform.position, Quaternion.identity) as GameObject;
				once=false;
			}
			timeLimit = 5; }
	}
}
