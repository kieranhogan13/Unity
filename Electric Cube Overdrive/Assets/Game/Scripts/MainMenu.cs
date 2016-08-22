using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour 
{
	public Texture2D backgroundTexture;
	public GUISkin mySkin = null;

	void OnGUI()
	{
		//Displays the menu background
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
		//Creates skin object
		GUI.skin = mySkin;

		//Simple navigation menu buttons
		if (GUI.Button (new Rect(Screen.width * 0.1f, Screen.height * 0.6f, Screen.width * 0.8f, Screen.height * 0.1f), "Play Game"))
		{
			print ("Clicked Play Game");
			//Loads the scene called "introduction"
			Application.LoadLevel("Introduction");
		}
		if (GUI.Button (new Rect(Screen.width * 0.1f, Screen.height * 0.7f, Screen.width * 0.8f, Screen.height * 0.1f), "Level Select"))
		{
			print ("Clicked Level Select");
			Application.LoadLevel("Level Select");
		}
		if (GUI.Button (new Rect(Screen.width * 0.1f, Screen.height * 0.8f, Screen.width * 0.8f, Screen.height * 0.1f), "Quit"))
		{
			print ("Clicked Quit");
			Application.Quit();
		}
	}
}
