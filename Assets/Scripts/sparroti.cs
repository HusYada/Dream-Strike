// Sparroti Script for Dream Strike by Huseyin Geyik

// Sparroti is just the rock but the other way around and different anims

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparroti : MonoBehaviour {

    public float speed;                 // The speed the rock is going
    public float length;                // The length the rock is from rockmiddle
    public bool preparing = true;       // Checks if the rock is preparing
    public bool jumping = false;        // Checks if the rock is jumping
    public bool landing = false;        // Checks if the rock is landing
    public int prepend;                 // When the rock prepares
    public int landend;                 // When the rock lands
    private int rockcooldown = 0;       // The rock cooldown timer
    private float rockpos = 4.8001f;    // The rock's position
    private float rockstart = 4.8f;     // Where the rock starts it's jump
    private float rockend = 7.8f;       // Where the rock ends it's jump
    private Vector2 rockmiddle;         // The point between where the rock jumps
    private Animator anim;              // The animator for the rock
    private SpriteRenderer sr;          // The sprite renderer for the rock
 
    public void Start() {

        // Getting components and position
        rockmiddle = transform.position;
        anim = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
    }
 
    public void FixedUpdate() {

        // Cooldown timer is ongoing
        rockcooldown++;

        // If the rock has finished preparing, then it will jump
        if(rockcooldown >= prepend && preparing == true) {
            jumping = true;
            preparing = false;
            landing = false;
            anim.SetBool("Idle", false);
        }

        // If the rock has landed, then it will start preparing the next jump
        if(rockcooldown >= landend && landing == true) {
            jumping = false;
            preparing = true;
            landing = false;
            rockcooldown = 0;
            sr.flipX = !sr.flipX;
            anim.SetBool("Idle", true);
        }

        if(preparing == true) {
        }

        // If the rock is jumping, it will move from start to end
        if(jumping == true) {

            preparing = false;
                
            if(rockpos >= rockend || rockpos <= rockstart) {
                if((rockpos >= rockend || rockpos <= rockstart) && rockcooldown > 50) {
                    landing = true;
                }
                speed *= -1;
            }

            // The jump
            rockpos += speed * Time.deltaTime;

            // Offset is determined depending on the rock's position
            Vector2 rockmiddleoffset = new Vector2(Mathf.Sin(rockpos), Mathf.Cos(rockpos)) * length;
            transform.position = rockmiddle - rockmiddleoffset;
        }

        // If the rock is landing, then it's not jumping
        if(landing == true) {
            jumping = false;
            anim.SetBool("Idle", true);
            //anim.SetInteger("State", 2);
        }
    }

}
