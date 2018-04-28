using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sparroti : MonoBehaviour {

    public float RotateSpeed;
    public float Radius;
    public bool preparing = true;
    public bool jumping = false;
    public bool landing = false;
    private int counter = 0;
    public int prepend;
    public int landend;
    private float _angle = 4.8001f;
    private float start = 4.8f;
    private float end = 7.8f;
    private Vector2 _centre;
    //private Animator anim;
    private SpriteRenderer sr;
 
    public void Start() {
        _centre = transform.position;
        //anim = this.GetComponent<Animator>();
        sr = this.GetComponent<SpriteRenderer>();
    }
 
    public void FixedUpdate() {

        counter++;

        if(counter >= prepend && preparing == true) {
            jumping = true;
            preparing = false;
            landing = false;
            //anim.SetInteger("State", 1);
        }

        if(counter >= landend && landing == true) {
            jumping = false;
            preparing = true;
            landing = false;
            counter = 0;
            sr.flipX = !sr.flipX;
            //anim.SetInteger("State", 0);
        }

            if(preparing == true) {
        }

        if(jumping == true) {

            preparing = false;
                
            if(_angle >= end || _angle <= start) {
                if((_angle >= end || _angle <= start) && counter > 50) {
                    landing = true;
                }
                RotateSpeed *= -1;
            }

            _angle += RotateSpeed * Time.deltaTime;

            var offset = new Vector2(Mathf.Sin(_angle), Mathf.Cos(_angle)) * Radius;
            transform.position = _centre - offset;
        }

        if(landing == true) {
            jumping = false;
            //anim.SetInteger("State", 2);
        }
    }

}
