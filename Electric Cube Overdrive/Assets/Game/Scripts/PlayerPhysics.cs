using UnityEngine;
using System.Collections;

public class PlayerPhysics : MonoBehaviour 
{
	public LayerMask collisionMask;

	public bool grounded;
	public bool stopped;
	public bool atWall;

	private BoxCollider2D collision;
	private Vector2 size;
	private Vector2 center;
	private Vector2 pos; 
	private float gap = .0005f;
	

	Ray2D ray;
	RaycastHit2D hit;

	void Start()
	{
		collision = GetComponent<BoxCollider2D>();
		size = collision.size;
		center = collision.center;
	}
	
	public void Move(Vector2 moveAmount)
	{
		// For up and down collision detection
		grounded = false;
		for (int i = 0; i<3; i++)
		{
			pos = transform.position;
			float dir  = Mathf.Sign (moveAmount.y);
			float x = (pos.x + center.x - size.x/2) + size.x/2 * i; // Let, centre and right point of collider
			float y = pos.y + center.y + size.y/2 * dir; // Bottom of collisionr
			ray = new Ray2D(new Vector2(x, y), new Vector2(0, dir));
			Debug.DrawRay(ray.origin, ray.direction);
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
				grounded = true;
				break;
			}
		}
		// For left and right collision detection
		stopped = false;
		atWall = false;

		if (moveAmount.x != 0)
		{
			for (int i = 0; i<3; i++)
			{
				float dir  = Mathf.Sign (moveAmount.x);
				float x = pos.x + center.x + size.x/2 * dir; 
				float y = pos.y + center.y - size.y/2 + size.y/2 * i;
				ray = new Ray2D(new Vector2(x, y), new Vector2(dir, 0));
				Debug.DrawRay(ray.origin, ray.direction);
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
					stopped = true;
					break;
				}
			}
		}
		// For player direction (angular) collision detection
		if (!grounded && !stopped)
		{
			Vector2 playerDir = new Vector2 (moveAmount.x, moveAmount.y);
			Vector2 o = new Vector2(pos.x + center.x + size.x/2 * Mathf.Sign(moveAmount.x), pos.y + center.y - size.y/2 + size.y/2 * Mathf.Sign(moveAmount.y));
			ray = new Ray2D (o, playerDir.normalized);
			Debug.DrawRay(ray.origin, ray.direction);
			hit = Physics2D.Raycast (ray.origin, ray.direction, Mathf.Sqrt(moveAmount.x * moveAmount.x + moveAmount.y * moveAmount.y), collisionMask);
			if (hit.collider == null)
			{
				grounded = false;
			}
		}

		Vector2 finalTransform = new Vector2(moveAmount.x, moveAmount.y);
		transform.Translate (finalTransform);
	}
	
}
