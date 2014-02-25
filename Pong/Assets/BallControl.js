#pragma strict

function Start () 
{
	yield WaitForSeconds(2);
	GoBall();
}
//allows space to reset ball to centre
function Update ()
{
	if (Input.GetKeyDown ("space"))
	{
		ResetBall();
	}
}
//causes ball to collide with paddles
function OnCollisionEnter2D (colInfo : Collision2D) 
{
	if (colInfo.collider.tag == "Player")
	{
		rigidbody2D.velocity.y = rigidbody2D.velocity.y/2 + colInfo.collider.rigidbody2D.velocity.y/3;
		audio.pitch = Random.Range(0.85f, 1.15f);
		audio.Play();
	}
}
//function for resetting ball
function ResetBall()
{
	transform.position.x = 0;
	transform.position.y = 0;
	rigidbody2D.velocity.x = 0; 
	rigidbody2D.velocity.y = 0;
	
	yield WaitForSeconds (1);
	GoBall();
}
// function for ball movement and adds force from paddle hit
function GoBall()
{
	var randomNumber = Random.Range(0, 1.5);
	var ballSpeed : float = 75;	
	if (randomNumber <= .75)
	{
		rigidbody2D.AddForce (new Vector2 (ballSpeed, 20));
	}
	else
	{
		rigidbody2D.AddForce (new Vector2 (-ballSpeed, -20));
	}
}