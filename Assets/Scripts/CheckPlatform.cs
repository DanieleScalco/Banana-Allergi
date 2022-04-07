using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPlatform : MonoBehaviour {

	public GameObject[] moveButtons;

    // Start is called before the first frame update
    void Start() {
	    if (Application.platform != RuntimePlatform.Android) {
		    foreach (GameObject button in moveButtons) {
			    button.SetActive(false);
		    }
	    }
    }

    // Update is called once per frame
    void Update() {
        
    }
}
