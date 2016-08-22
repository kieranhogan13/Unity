using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerPhysics))] // Links Controller to Physics permanently

public class PlayerController : Life
{
	public float gravity = 20;
	public float regSpeed = 10;
	public float dashSpeed = 20;
	public float acceleration = 30;
	public float jumpHeight = 15;
	
	private float currentSpeed;
	private float targetSpeed;
	private float speed = 10;
	private Vector2 amountToMove;
	
	private PlayerPhysics playerPhysics;
	private bool atWall;
	// Use this for initialization
	void Start () 
	{
		playerPhysics = GetComponent<PlayerPhysics>();
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (playerPhysics.stopped)
		{
			targetSpeed = 0;
			currentSpeed = 0;
		}
		speed = regSpeed;
		if (playerPhysics.grounded && Input.GetKey(KeyCode.LeftShift))
		{
			speed = dashSpeed;
		}

		if (Input.GetKey(KeyCode.Space))
		{
			if (playerPhysics.grounded || atWall)
			{
				amountToMove.y = jumpHeight;
				playerPhysics.grounded = false;
				if (atWall)
				{
					atWall = false;
				}
			}
		}
		
		targetSpeed = Input.GetAxisRaw("Horizontal") * speed;
		currentSpeed = IncrementTowards (currentSpeed, targetSpeed, acceleration);

		if (playerPhysics.grounded) // Allows jumping from ground 
		{
			amountToMove.y = 0;
			if (atWall)
			{
				atWall = false;
			}

			if (Input.GetKey(KeyCode.Space))
			{
				amountToMove.y = jumpHeight;
				playerPhysics.grounded = false;
			}
		}
		else
		{
			if (!atWall)
			{
				if (playerPhysics.atWall)
				{
					atWall = true;
				}
			}
		}
		
		amountToMove.x = currentSpeed;

		if (atWall)
		{
			if (Input.GetAxisRaw("Vertical") != -1)
			{
				amountToMove.y -= gravity * Time.deltaTime;
			}
		}
		amountToMove.y -= gravity * Time.deltaTime;
		playerPhysics.Move (amountToMove * Time.deltaTime);
	}
	
	// Increase n towards target by speed
	private float IncrementTowards(float curr, float target, float acc) // n = current speed
	{
		if (curr == target) 
		{
			return curr;
		} 
		else
		{
			float dir = Mathf.Sign (target - curr); // Must be increased or decreased to get closer to target
			curr += acc * Time.deltaTime * dir;
			return (dir == Mathf.Sign (target - curr))? curr : target; // If curr has now passed target then return target , otherwise return curr
		}
	}
}