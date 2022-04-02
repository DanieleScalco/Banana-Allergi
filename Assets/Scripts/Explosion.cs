using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour {

	private float explodingSpeed = 30;

	// Start is called before the first frame update
    void Start() {

    }

	// Update is called once per frame
	void Update() {

	    transform.position = GameObject.Find("Monkey").transform.position;

	    transform.localScale += Vector3.one * Time.deltaTime * explodingSpeed;
	    if (transform.localScale.x > 20) {
			Destroy(gameObject);
	    }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
	    if (collision.gameObject.CompareTag("Banana")) {
		    Destroy(collision.gameObject);
	    }
    }




}
