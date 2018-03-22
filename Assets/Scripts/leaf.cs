using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class leaf : MonoBehaviour {

    public GameObject platform;
    public GameObject target;
    public bool cango = false;
    public bool makeplatform = false;
    private bool reached = false;

    // The speed the enemy will go through the way point, edit it in the Inspector
    public float speed;

	void Update() {

        if(cango == true) {
            Vector2 pos = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
            GetComponent<Rigidbody2D>().MovePosition(pos);
        }

        if(reached == true) {
            if(makeplatform == true) {
                Transform.Instantiate(platform, transform.position, transform.rotation);
            }

            Destroy(this.gameObject);
        }
	}

    void OnTriggerEnter2D(Collider2D col) {
        if(col.transform.gameObject == target) {
            reached = true;
        }
    }

    void OnTriggerStay2D(Collider2D col) {
        if(col.transform.gameObject == target) {
            reached = true;
        }
    }
}
