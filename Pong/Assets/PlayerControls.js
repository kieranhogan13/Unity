#pragma strict

var moveUp : KeyCode;
var moveDown : KeyCode;
var speed : float = 8;

//controls and restricts player movement to vertical only within top and bottom boundaries
function Update () 
{
	if (Input.GetKey(moveUp))
	{
		rigidbody2D.velocity.y = speed;
	}
	else if (Input.GetKey(moveDown))
	{
		rigidbody2D.velocity.y = speed * -1;
	}
	else
	{
		rigidbody2D.velocity.y = 0;
	}
	
	rigidbody2D.velocity.x = 0;
}