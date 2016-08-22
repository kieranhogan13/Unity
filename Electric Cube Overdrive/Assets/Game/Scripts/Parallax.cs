using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour 
{
	public float speed = 0;
	
	void Update () 
	{
		//Offsets the background using a vector, and unity allows it to loop
		renderer.material.mainTextureOffset = new Vector2 ((Time.time * speed)%1, 0f);
	}
}
