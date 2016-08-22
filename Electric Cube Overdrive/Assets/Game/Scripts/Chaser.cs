using UnityEngine;
using System.Collections;

public class Chaser: Enemy
{
	//Chaser inherits from Enemy parent class
	public Transform target;
	public float speed = 5f; //speed of chaser
	public float distance = 10f; //distance for it to chase
	
	public override void Update () 
	{   
		transform.LookAt(target.position); //causes the sphere to chase the player
		transform.Rotate(new Vector3(0,-90,0),Space.Self); //corrects the rotation, not clear because object is sphere

		if (Vector3.Distance(transform.position,target.position)<distance)
		{
			//if the target (in this case player) is within the range of the chaser
			//move at specified speed if distance from target is greater than specified distance
			transform.Translate(new Vector3(speed* Time.deltaTime,0,0) );
		}
	}
}