using UnityEngine;
using System.Collections;

public class Xer : Enemy
{
	//Xer extends enemy class, Xer is an enemy that moves along x coords
	public float moveSpeed = 3.0f;
	public float moveDirection = 3.0f;
	//Coordinates for Xer and Yer
	public float coordLeft = -2.0f;
	public float coordRight = 2.0f;
	public float coordUp = -2.0f;
	public float coordDown = 2.0f;
	public Vector3 moveAmount;
	
	public override void Update () 
	{
		Move();
	}

	public override void Move()
	{
		//Sets only to change x position
		moveAmount.x = moveDirection * moveSpeed * Time.deltaTime;
		
		if (moveDirection > 0.0f && transform.position.x >= coordRight)
		{
			//Sets amount to move the Xer along x
			moveDirection = -3.0f;
		}
		else if (moveDirection < 0.0f && transform.position.x <= coordLeft)
		{
			//Sets amount to move the Xer along x, opposite way
			moveDirection = 3.0f;
		}
		//Moves the Xer by amount
		transform.Translate(moveAmount);
	}
}
