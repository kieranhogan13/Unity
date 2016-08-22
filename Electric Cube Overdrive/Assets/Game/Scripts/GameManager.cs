using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour 
{
	public GameObject player;
	public static int levelCount = 5;
	public static int currentLevel;
	private bool paused = false;
	public GUISkin mySkin = null;
	
	void Start()
	{
		//Ensures that time is normal
		Time.timeScale = 1;
	}

	void Update()
	{
		if (Input.GetButtonDown ("Pause"))
		{
			//Pause system
			print("Pressed Pause");
			paused = switchPause();
		}
	}
	
	void OnGUI()
	{
		GUI.skin = mySkin;
		//Displays the level name on screen
		GUI.Label (new Rect (Screen.width * 0.87f, Screen.height * 0.03f, Screen.width * 0.4f, Screen.height * 0.2f), Application.loadedLevelName);
		if (Input.GetButtonDown ("Respawn"))
		{
			//Respawn system, restarts the level
			print("Pressed respawn");
			Application.LoadLevel(Application.loadedLevel);
			Time.timeScale = 1;
		}
		if (Input.GetButtonDown ("Quit"))
		{
			//Quit system, returns to menu
			print("Pressed quit");
			Application.LoadLevel("Main Menu");
			Time.timeScale = 1;
		}
		if (paused)
		{
			//Pause menu, displays certain options for player
			GUI.Label (new Rect (Screen.width * 0.4575f, Screen.height * 0.3f, Screen.width * 0.5f, Screen.height * 0.6f), "Paused");
			GUI.Label (new Rect (Screen.width * 0.4175f, Screen.height * 0.4f, Screen.width * 0.6f, Screen.height * 0.6f), "R to respawn");
			GUI.Label (new Rect (Screen.width * 0.3675f, Screen.height * 0.5f, Screen.width * 0.7f, Screen.height * 0.6f), "Q to quit to main menu");
			if (Input.GetButtonDown ("Pause"))
			{
				//Switches pause
				if(GUILayout.Button(""))paused = switchPause();
			}
		}
	}

	bool switchPause()
	{
		//Pause system, using very small timescale, but not 0
		if (Time.timeScale == 0.000001f)
		{
			Time.timeScale = 1;
			return (false);
		}
		else
		{
			Time.timeScale = 0.000001f;
			return(true);
		}
	}
	
	public void EndLevel()
	{
		//End Level, loads the current level number
		currentLevel = Application.loadedLevel;
		if (currentLevel < levelCount)
		{
			//If its not the last level, it increments
			currentLevel++;
			Time.timeScale = 1;
			Application.LoadLevel("Level " + currentLevel);
		}
		else
		{
			//Otherwise it returns to the main menu
			currentLevel = 1;
			Application.LoadLevel("Main Menu");
		}
	}
}