using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparroti : MonoBehaviour {

	// The target the enemy is going to shoot at, edit it in the Inspector
	public Transform player;

 	// The starting x position of the enemy
	private float startposx;
	private float startposy;

	// The speed the enemy will move at, edit it in the Inspector
	public float speed;
	//public float jump;

	// The distance the enemy can see the player before attacking, edit it in the Inspector
	//public float distance;

	// The width the enemy will travel before turning around, edit it in the Inspector
 	public float width;
 	public float height;

 	private float direction = -1;

 	//public bool waitjump = true;
 	private bool lookleft = false;
 	//public Vector3 leftvector = new Vector3(0, 180); 	// A vector that looks left
   	//public Vector3 rightvector = new Vector3(0, 0); 	// A vector that looks right

 	/*public bool rock_iscooldown;
    public int rock_cooldowntime;
    public int rock_cooldowncounter;*/


 	// Checks if the player is in the range of the enemy
	//private bool range = false;

	//private Rigidbody2D rb;
	private Animator anim;
  
	void Start() {

		// Setting the starting x position to it's current x position
    	startposx = transform.position.x;
    	startposy = transform.position.y;

    	//rb   = this.GetComponent<Rigidbody2D>();
    	anim = this.GetComponent<Animator>();
 	}

    //FixedUpdate is used for physics and such
    void Update() {

    	// velocitystop = rb.velocity;

 		// The range is set to be less than the distance
		//range = Vector3.Distance (transform.position, player.position) < distance;

 		// Checks if the player is within it's range
 		//if (range) {

			// If the enemy is going right and travels the width, it will turn around
			// If the enemy is going left and travels past it's intial starting x position, it will turn around
    		//if ((speed > 0 && transform.position.x >= startposx + width && rock_iscooldown == false) || (speed <= 0 && transform.position.x <= startposx && rock_iscooldown == false)) {
    		if ((transform.position.x >= startposx + width) || (transform.position.x <= startposx)) {

        		//speed *= -1;
        		lookleft = !lookleft;
        		//rock_iscooldown = true;
        		//waitjump = true;
        		anim.Play("sparroti", 0, 0f);
        		if(lookleft == true) {
        			transform.eulerAngles = new Vector3(0, 180);
        		} else if(lookleft == false) {
        			transform.eulerAngles = new Vector3(0, 0);
        		}

        		//Debug.Log(transform.position.y);
        		/*velocitystop.x = 0.0f;
				rb.velocity = velocitystop;
				waitjump = true;*/
        		
            }

            /*if ((jump > 0 && transform.position.y >= startposy + height) || (jump <= 0 && transform.position.y <= startposy)) {

        		jump *= -1;
            }*/

            //if(transform.position.x <= startposx + width || transform.position.x >= startposx) {
            	transform.Translate (new Vector3 (0.5f, 0.0f, 0.0f) * speed * Time.deltaTime);
            	transform.Translate (new Vector3 (0.0f, 0.5f * direction, 0.0f) * speed * Time.deltaTime);
        	//}

            /*if(transform.position.y == startposy) {
            	transform.Translate (new Vector3 (0.0f, -0.5f, 0.0f) * speed * Time.deltaTime);
            }

            if(transform.position.y == startposy + height/2) {
            	transform.Translate (new Vector3 (0.0f, 0.5f, 0.0f) * speed * Time.deltaTime);
            }*/

            /*if(transform.position.y >= startposy + height/2) {

            	transform.Translate (new Vector3 (0.0f, 0.5f * direction, 0.0f) * speed * Time.deltaTime);
            	direction * -1;
        	} else if(transform.position.y <= startposy + height/2) {
        		transform.Translate (new Vector3 (0.0f, -0.5f * direction, 0.0f) * speed * Time.deltaTime);
        		direction * -1;
        	}*/

        	if ((transform.position.x >= startposy + height) || (transform.position.x <= startposy)) {
        		direction *= -1;
        	}

            //transform.Translate (new Vector3 (0.0f, 0.5f, 0.0f) * jump * Time.deltaTime);

            //transform.Translate (new Vector3 (0.5f * speed, 0.5f * jump, 0.0f) * Time.deltaTime);
            //rb.AddForce(new Vector2 (speed, jump));
            //rb.AddForce(new Vector2 (speed, 0.0f));

            //if(waitjump == true) {
            	
            //}

            //startposx = Mathf.PingPong(Time.time, 4);
            //startposy = Mathf.PingPong(Time.time, 2);

            //transform.Translate (new Vector3 (startposx, startposy, 0.0f) * Time.deltaTime);

            //transform.position = new Vector3(Mathf.PingPong(Time.time, startposx), Mathf.PingPong(Time.time, startposy), transform.position.z);

        //}

        /*if(range == true) {
        	if(player.position.x <= this.transform.position.x) {
        		speed = -8;
        	} else if(player.position.x >= this.transform.position.x) {
        		speed = 8;
        	}
        }*/

        // If the menu screen has changed, a counter will start
		/*if (rock_iscooldown == true) {
           	rock_cooldowncounter++;
       	}

       	// If the menu counter is equal to its time, the menu screen can be changed again
	  	if (rock_cooldowncounter >= rock_cooldowntime) {
            rock_iscooldown = false;
           	rock_cooldowncounter = 0;
        }*/
    }

    //void OnCollisionEnter2D(Collision2D col) {
    	//if(col.gameObject.tag == "Gnd" && range == true) {
    	/*if(col.gameObject.tag == "Gnd") {
    		waitjump = true;
    	}*/
    //}

    //void OnCollisionExit2D(Collision2D col) {
    	//if(col.gameObject.tag == "Gnd" && range == true) {
    	/*if(col.gameObject.tag == "Gnd") {
    		waitjump = false;
    	}*/
    //}
//}

}
