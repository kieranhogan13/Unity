using UnityEngine;
using System.Collections;

public class Danger : MonoBehaviour 
{
	
	// Update is called once per frame
	public virtual void Update () 
	{
		move();
	}

	public virtual void move()
	{
		//Danger doesn't move
	}

	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.tag == "Player")
		{
			collision.GetComponent<Life>().TakeDamage(5);
		}
	}
}