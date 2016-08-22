using UnityEngine;
using System.Collections;

public class LevelSelect : MainMenu
{
	//Inherits from MainMenu class
	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
		GUI.skin = mySkin;

		//Simple level select system
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.2f, Screen.width * 0.8f, Screen.height * 0.1f), "Level 1"))
		{
			print ("Clicked Level 1");
			Application.LoadLevel("Level 1");
		}
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.3f, Screen.width * 0.8f, Screen.height * 0.1f), "Level 2"))
		{
			print ("Clicked Level 2");
			Application.LoadLevel("Level 2");
		}
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.1f), "Level 3"))
		{
			print ("Clicked Level 3");
			Application.LoadLevel("Level 3");
		}
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.5f, Screen.width * 0.8f, Screen.height * 0.1f), "Level 4"))
		{
			print ("Clicked Level 4");
			Application.LoadLevel("Level 4");
		}
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.6f, Screen.width * 0.8f, Screen.height * 0.1f), "Level 5"))
		{
			print ("Clicked Level 5");
			Application.LoadLevel("Level 5");
		}
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.7f, Screen.width * 0.8f, Screen.height * 0.1f), "Back"))
		{
			print ("Clicked Back");
			Application.LoadLevel("Main Menu");
		}
	}
}
