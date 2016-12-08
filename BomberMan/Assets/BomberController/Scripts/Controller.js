#pragma strict


var animator : Animator; //stores the animator component
var v : float; //vertical movements
var h : float; //horizontal movements

var Drop : boolean;

var Bomber : GameObject;
var Pos: Transform;

var put : boolean;
var Bomba : GameObject;
var Player: GameObject;

function Start () {

put = true;
Drop = false;

}

function Update () {

v = Input.GetAxis("Vertical");
h = Input.GetAxis("Horizontal");
Dropping();




}

function FixedUpdate () {
	
animator.SetFloat ("Walk", v);
animator.SetFloat ("Turn", h);
animator.SetBool("Drop", Drop);

}

function Dropping() {
	
	if(Input.GetKeyDown("space")){
		
		Drop= true;
	}else{
		Drop = false;
	}
	
	if(Drop == true && put == true){
		
		Instantiate(Bomber,Pos.position, transform.rotation);
	}
}

function OnTriggerEnter(Col: Collider){
	
	
	if(Col.gameObject.tag == "Finish"){
		put = false;
		
	}
	
} 

function OnTriggerExit(Col: Collider){
	
	
	if(Col.gameObject.tag == "Finish"){
		put = true;
		
	}
	
} 

    function OnParticleCollision()
    {
     Bomba.SetActive(true);
	 Player.SetActive(false);
	 Destroy(gameObject,2);
     Debug.Log("My Player's been hit by particles.");
    }