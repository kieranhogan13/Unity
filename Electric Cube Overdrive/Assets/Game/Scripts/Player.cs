using UnityEngine;
using System.Collections;

public class Player : Alive
{
	public LayerMask collisionMask;
	public float gravity = 30;
	public float regSpeed = 15;
	public float dashSpeed = 20;
	public float acceleration = 30;
	public float jumpHeight = 20;

	private bool onGround;
	private bool notMoving;
	private bool atWall;
	private BoxCollider2D collision;
	private Vector2 size;
	private Vector2 center;
	private Vector2 position; 
	private float gap = .0005f;

	private float current;
	private float target;
	private float speed = 10;
	private Vector2 amountToMove;

	Ray2D ray;
	RaycastHit2D hit;

	public override void Start()
	{
		collision = GetComponent<BoxCollider2D>();
		size = collision.size;
		center = collision.center;
	}

	public override void Update () 
	{
		if (notMoving)
		{
			target = 0;
			current = 0;
		}
		speed = regSpeed;
		if (onGround && Input.GetKey(KeyCode.LeftShift))
		{
			speed = dashSpeed;
		}
		
		if (Input.GetKey(KeyCode.Space))
		{
			if (onGround || atWall)
			{
				amountToMove.y = jumpHeight;
				onGround = false;
				if (atWall)
				{
					atWall = false;
				}
			}
		}
		target = Input.GetAxisRaw("Horizontal") * speed;
		current = Increase (current, target, acceleration);
		if (onGround) 
		{
			//Allows jumping from ground
			amountToMove.y = 0;
			if (atWall)
			{
				atWall = false;
			}
			
			if (Input.GetKey(KeyCode.Space))
			{
				amountToMove.y = jumpHeight;
				onGround = false;
			}
		}
		else
		{
			//Allows jumping from wall
			if (!atWall)
			{
				if (atWall)
				{
					atWall = true;
				}
			}
		}
		amountToMove.x = current;
		if (atWall)
		{
			if (Input.GetAxisRaw("Vertical") != -1)
			{
				amountToMove.y -= gravity * Time.deltaTime;
			}
		}
		amountToMove.y -= gravity * Time.deltaTime;
		Move (amountToMove * Time.deltaTime);
	}
	// Increase n towards target by speed
	private float Increase (float cSpeed, float tSpeed, float acceleration) // n = current speed
	{
		if (cSpeed == tSpeed) 
		{
			return cSpeed;
		} 
		else
		{
			//Gets the difference
			float direction = Mathf.Sign (tSpeed - cSpeed);
			//Uses time and acceleartion
			cSpeed += acceleration * Time.deltaTime * direction;
			//If cSpeed has now passed tSpeed then return tSpeed , otherwise return cSpeed
			if (direction == Mathf.Sign (tSpeed - cSpeed))
			{
				return cSpeed;
			}
			else
			{
				return tSpeed; 
			}

		}
	}


	public void Move(Vector2 moveAmount)
	{
		//For vertical collisions
		onGround = false;
		for (int i = 0; i<3; i++)
		{
			//3 seperate rays, one for each corner, one for middle
			position = transform.position;
			float dir  = Mathf.Sign (moveAmount.y);
			//Positions rays
			float x = (position.x + center.x - size.x/2) + size.x/2 * i;
			float y = position.y + center.y + size.y/2 * dir;
			//Initialises Rays
			ray = new Ray2D(new Vector2(x, y), new Vector2(0, dir));
			//Draws Ray for debugging
			Debug.DrawRay(ray.origin, ray.direction);
			//Detects if the rays collide with object (including gap)
			hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs (moveAmount.y) + gap, collisionMask);
			if (hit.collider != null)
			{
				float dist = Vector2.Distance (ray.origin, hit.point); // Distance between player and ground

				if (dist > gap)
				{
					moveAmount.y = dist * dir - gap * dir;
				}
				else
				{
					moveAmount.y = 0;
				}
				onGround = true;
				break;
			}
		}

		notMoving = false;
		atWall = false;
		if (moveAmount.x != 0)
		{
			//For horizontal collisions
			for (int i = 0; i<3; i++)
			{
				//3 seperate rays, one for each corner, one for middle
				float dir  = Mathf.Sign (moveAmount.x);
				//Positions rays
				float x = position.x + center.x + size.x/2 * dir; 
				float y = position.y + center.y - size.y/2 + size.y/2 * i;
				//Initialises Rays
				ray = new Ray2D(new Vector2(x, y), new Vector2(dir, 0));
				//Draws Ray for debugging
				Debug.DrawRay(ray.origin, ray.direction);
				//Detects if the rays collide with object (including gap)
				hit = Physics2D.Raycast(ray.origin, ray.direction, Mathf.Abs (moveAmount.x) + gap, collisionMask);
				if (hit.collider != null)
				{
					if (hit.collider.tag == "Wall")
					{
						atWall = true;
					}
					float dist = Vector2.Distance (ray.origin, hit.point); // Distance between player and ground
					
					if (dist > gap)
					{
						moveAmount.x = dist * dir - gap * dir;
					}
					else
					{
						moveAmount.x = 0;
					}
					notMoving = true;
					break;
				}
			}
		}
		if (!onGround && !notMoving)
		{
			//For angular collision detection
			Vector2 playerDir = new Vector2 (moveAmount.x, moveAmount.y);
			Vector2 o = new Vector2(position.x + center.x + size.x/2 * Mathf.Sign(moveAmount.x), position.y + center.y - size.y/2 + size.y/2 * Mathf.Sign(moveAmount.y));
			//Initialises Rays
			ray = new Ray2D (o, playerDir.normalized);
			//Draws Ray for debugging
			Debug.DrawRay(ray.origin, ray.direction);
			hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Sqrt(moveAmount.x * moveAmount.x + moveAmount.y * moveAmount.y), collisionMask);
			if (hit.collider == null)
			{
				onGround = false;
			}
		}
		//Moves player
		Vector2 finalTransform = new Vector2(moveAmount.x, moveAmount.y);
		transform.Translate (finalTransform);
	}
	
}
