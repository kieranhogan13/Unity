using UnityEngine;
using System.Collections;

public class Yer : Xer
{
	//Xer only needs to override Yer's Move() function, all else inherited
	public override void Move()
	{
		//Sets only to change y position
		moveAmount.y = moveDirection * moveSpeed * Time.deltaTime;
		
		if (moveDirection > 0.0f && transform.position.y >= coordUp)
		{
			//Sets amount to move the Yer via y
			moveDirection = -3.0f;
		}
		else if (moveDirection < 0.0f && transform.position.y <= coordDown)
		{
			//Sets amount to move the Yer via y, opposite way
			moveDirection = 3.0f;
		}
		//Moves the Yer by amount
		transform.Translate(moveAmount);
	}
}
