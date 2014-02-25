#pragma strict
//Triggers for left and right wall that make noise and reset ball
function OnTriggerEnter2D (hitInfo : Collider2D) 
{
	if (hitInfo.name == "Ball")
	{
		var wallName = transform.name;
		audio.Play();
		GameManager.Score (wallName);
		hitInfo.gameObject.SendMessage ("ResetBall");
	}
}