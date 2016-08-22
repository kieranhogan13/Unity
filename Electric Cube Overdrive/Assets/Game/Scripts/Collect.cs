using UnityEngine;
using System.Collections;

public class Collect : MonoBehaviour 
{
	public GUISkin mySkin = null;
	public GameManager GameMan; //references the gammanager class

	private int curScore;
	private int maxScore = 5;
	private bool end;

	void OnGUI()
	{
		GUI.skin = mySkin;
		//Displays the players score
		GUI.Label (new Rect (Screen.width * 0.03f, Screen.height * 0.03f, Screen.width * 0.4f, Screen.height * 0.2f), "Data Collected: " + curScore + " / " + maxScore);
		if (end)
		{
			print ("Player completed level");
			if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.4f, Screen.width * 0.8f, Screen.height * 0.1f), "Continue"))
			{
				//GUI Buttons for interface
				print ("Clicked Continue");
				//Allows the use of the EndLevel() method in GameManager
				GameMan.EndLevel();
			}
			if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.5f, Screen.width * 0.8f, Screen.height * 0.1f), "Final Data Collected: " + curScore + " / " + maxScore + " - Click to retry"))
			{
				print ("Clicked Retry");
				//Reloads the level
				Application.LoadLevel(Application.loadedLevel);
			}
			if (GUI.Button (new Rect(Screen.width *  0.1f, Screen.height * 0.6f, Screen.width * 0.8f, Screen.height * 0.1f), "Main Menu"))
			{
				print ("Clicked Quit");
				//Loads the main menu
				Application.LoadLevel("Main Menu");
			}
			}
	}
	
	void OnTriggerEnter2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Collect")
		{
			//When the player collects data, plays a noise, 
			//increases score by 1 and destroys the object
			audio.Play();
			print ("Player collected data");
			curScore++;
			Destroy(collider.gameObject);
		}
		if (collider.gameObject.tag == "End Level")
		{
			//Ends the level, continued in GUI
			end = true;
			Time.timeScale = 0.000001f;
		}
	}
}
