using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveLeft : MonoBehaviour {

    private float speed;
    private float boundLeft = -30;

    // Start is called before the first frame update
    void Start() {
	    speed = Random.Range(1.0f, 2.0f);
    }

    // Update is called once per frame
    void Update() {
        transform.Translate(speed * Time.deltaTime * Vector3.left);

        if (transform.position.x < boundLeft) {
            Destroy(gameObject);
	    }
    }
}
