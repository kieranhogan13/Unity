using UnityEngine;
using System.Collections;

public class Enemy : Alive 
{
	//Basic enemy inherits from alive class
	public override void Update () 
	{
		Move();
	}

	public virtual void Move()
	{
		//Basic enemy doesn't move
	}

	public virtual void OnTriggerEnter2D(Collider2D collision)
	{
		//The collision that kills the player exists in the enemy class, and 
		//is inherited by the different enemy types Chaser, Xer, and Yer
		if (collision.tag == "Player")
		{
			collision.GetComponent<Alive>().PlayerKill();
		}
	}
}