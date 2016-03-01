using UnityEngine;
using System.Collections;

public class GameData
{
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
		get;
		set;
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
