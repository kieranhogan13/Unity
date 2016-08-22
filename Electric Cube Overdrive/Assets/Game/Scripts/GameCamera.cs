using UnityEngine;
using System.Collections;

public class GameCamera : MonoBehaviour 
{
	public Transform cameraTarget;

	private Vector2 velocity;
	private Transform mainTransform;

	void Start()
	{
		mainTransform = transform;
		velocity = new Vector2 (0.5f, 0.5f);
	}

	void Update()
	{
		Vector2 newPos2D = Vector2.zero;

		//SmoothDamp gradually changes x and y pos of camera, creating smooth movement
		newPos2D.x = Mathf.SmoothDamp (mainTransform.position.x, cameraTarget.position.x, ref velocity.x, .05f);
		newPos2D.y = Mathf.SmoothDamp (mainTransform.position.y, cameraTarget.position.y, ref velocity.y, .05f);
		//Moves the camera to follow the player using slerp between two vectors
		Vector3 newPos = new Vector3(newPos2D.x, newPos2D.y, transform.position.z);
		transform.position = Vector3.Slerp (transform.position, newPos, Time.time);

	}
}
