using UnityEngine;
using System.Collections;

public class ButtonBehaviour : MonoBehaviour {

	private GameObject startGame;
	private GameObject helpText;

	public void LoadLevelByName(string levelName)
	{
		Application.LoadLevel(levelName);
		Debug.Log("Button has been pressed");
		ScoreManager.score=0;
	
	}

	public void HelpButtonClicked(){
		UnityEngine.UI.Text text = GameObject.Find ("Canvas/Help/Text").GetComponent<UnityEngine.UI.Text> ();
		if (text.text == "Help") {
			text.text = "Back";
			startGame.SetActive (false);
			helpText.SetActive (true);
		} else {
			text.text = "Help";
			startGame.SetActive (true);
			helpText.SetActive (false);
		}
	}

	// Use this for initialization
	void Start () {
		startGame = GameObject.Find ("Canvas/StartGame");
		helpText = GameObject.Find ("Canvas/helpText");
		helpText.SetActive (false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
