using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBanana : MonoBehaviour {

	private Rigidbody2D rigidbody;
	public static float force = 500;

    // Start is called before the first frame update
    void Start() {

	    rigidbody = GetComponent<Rigidbody2D>();
	    Vector2 direction = new Vector2(Random.Range(-0.9f, 0.9f), -1);
        rigidbody.AddForce(direction * force, ForceMode2D.Force);

    }

    // Update is called once per frame
    void Update() {
	    
    }

	private void OnCollisionEnter2D(Collision2D collision) {

		if (collision.gameObject.name.Equals("TopCollider")) {
			Destroy(gameObject);
		}
	}

}
