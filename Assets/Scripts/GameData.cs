using UnityEngine.UI;
using System.Collections;
using UnityEngine;



public class GameData
{
	public static GameObject text;
	public int points = 0;
	public string score= "Score";
	private static GameData instance;
	 
	private GameData()
	{
		if(instance != null)
		{
			return;
		}
		instance = this;
		Paused = false;
	}
	
	
	//Properties
	public static GameData Instance
	{
		get
		{
			if(instance == null)
			{
				instance = new GameData();
			}
			return instance;
		}
	}


	public int Punkte {

		get {
			return points;}
		set {text = GameObject.Find("Text");
			points = value;
			text.GetComponent<UnityEngine.UI.Text>().text = score+ " " + points;}
		  
	}


	
	public bool Paused
	{
		get;
		set;
	}
	
	
	//Properties the short way
	/*
     * get;
     * set;
     */
}
