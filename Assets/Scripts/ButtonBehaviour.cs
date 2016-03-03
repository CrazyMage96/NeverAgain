using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	public void LoadLevelByName(string levelName)
	{
		Application.LoadLevel(levelName);
		Debug.Log("Button has been pressed");
		ScoreManager.score=0;
	
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
