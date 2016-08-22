using UnityEngine;
using System.Collections;

public class Life : MonoBehaviour 
{
	public float health = 5;
	public GUISkin mySkin = null;
	private bool isDead = false;
	
	void OnGUI()
	{
		GUI.skin = mySkin;
		if (isDead)
		{
			GUI.Box (new Rect(Screen.width *  0.25f, Screen.height * 0.5f, Screen.width * 0.5f, Screen.height * 0.1f), "You died");
			GUI.Box (new Rect(Screen.width *  0.25f, Screen.height * 0.6f, Screen.width * 0.5f, Screen.height * 0.1f), "Press R to respawn");
		}
	}

	public void TakeDamage (float dmg)
	{
		health -= dmg;
		if (health <= 0)
		{
			Die();
			isDead = true;
		}
	}
	public void Die()
	{
		Debug.Log ("DIE");
		if(transform.tag == "Player")
		{
			Time.timeScale = 0;
		}
	}
	
	void Start()
	{
		isDead = false;
	}
}
