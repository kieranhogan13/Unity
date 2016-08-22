using UnityEngine;
using System.Collections;

public class Introduction : MainMenu 
{
	//Inherits from MainMenu
	void OnGUI()
	{
		// Display background texture
		GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), backgroundTexture);
		GUI.skin = mySkin;
		//Short introduction for the player
		GUI.Box (new Rect(Screen.width *  0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.4f), "The Objective:\n" +
			"Run and jump through the levels, and avoid enemies and danger.\n" +
			"Collect as many data fragments as you can, and reach the finish.\n\n" +
			"The Controls:\n" +
			"Up, Down, Left and Right for character movement.\nSpacebar for jump and left shift for sprint\n" +
		    "By holding the jump button, you can climb walls,\nwall jump, or even hold onto ceilings.\n" +
		    "Press r to respawn and restart the level,\n" +
		    "Press p to pause, and q to quit to the main menu.");
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.8f, Screen.width * 0.8f, Screen.height * 0.1f), "Lets Go"))
		{
			print ("Clicked Begin");
			Application.LoadLevel("Level 1");
		}
		if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.9f, Screen.width * 0.8f, Screen.height * 0.1f), "Back"))
		{
			print ("Clicked Back");
			Application.LoadLevel("Main Menu");
		}
	}
}
