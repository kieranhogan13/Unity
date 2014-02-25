#pragma strict

static  var playerScore01 : int = -1;
static  var playerScore02 : int = -1;

var theSkin : GUISkin;

//controls scoring system for the game
static function Score (wallName : String) 
{
	if (wallName == "rightWall")
	{
		playerScore01 = playerScore01 + 1;
	}
	else if (wallName == "leftWall")
	{
		playerScore02 = playerScore02 + 1;
	}
}
//gives gui to score
function OnGUI ()
{
	GUI.skin = theSkin;
	GUI.Label (new Rect (Screen.width/2-150-30, 20, 150, 150), "P1: " + playerScore01);
	GUI.Label (new Rect (Screen.width/2+150-30, 20, 150, 150), "P2: " + playerScore02);
}