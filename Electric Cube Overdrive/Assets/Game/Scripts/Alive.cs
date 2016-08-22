using UnityEngine;
using System.Collections;

public class Alive : MonoBehaviour 
{
	//Alive is a base class for others to inherit from
	public GUISkin mySkin = null;

	private bool dead = false; //ensures the player is alive on play

	public virtual void Start () 
	{
		dead = false;
	}
	

	public virtual void Update () 
	{
	
	}

	public virtual void OnGUI()
	{
		GUI.skin = mySkin;
		if (dead)
		{
			//GUI for when the player dies
			GUI.Box (new Rect(Screen.width *  0.25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), "You died");
			GUI.Box (new Rect(Screen.width *  0.25f, Screen.height * 0.6f, Screen.width * 0.5f, Screen.height * 0.1f), "Press R to respawn");
		}
	}

	public void PlayerKill()
	{
		//Kills the player
		dead = true;
		print("Player killed");
		if(transform.tag == "Player")
		{
			Time.timeScale = 0;
		}
	}
}
