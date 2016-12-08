#pragma strict

var Bomb : GameObject;
var time : float;

var timer : float = 10;

function Start () {

//Bomb.SetActive(true);

}

function Update () {

timer -= Time.deltaTime;
	
	if(timer <= 0)
	{
		timer = 0;
	}

	if(timer == 0){
		Bomb.SetActive(true);
		
	}
	
	


Destroy(gameObject,time);
}

function OnParticleCollision(hit : GameObject){

    if(hit.gameObject.FindWithTag=="Player" || hit.gameObject.FindWithTag=="Crate" ){
        Debug.Log("Some Message");  
    }
	

}