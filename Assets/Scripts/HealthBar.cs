using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour {

	public GameObject[] hearts;

    // Start is called before the first frame update
    void Start() {
        
    }

    // Update is called once per frame
    void Update() {

	    switch (PlayerController.health) {
		    case 3:
			    foreach (GameObject h in hearts) {
                    h.SetActive(true);
				};
			    break;
            case 2:
                hearts[0].SetActive(true);
                hearts[1].SetActive(true);
                hearts[2].SetActive(false);
                break;
            case 1:
	            hearts[0].SetActive(true);
	            hearts[1].SetActive(false);
	            hearts[2].SetActive(false);
	            break;
            case 0:
	            foreach (GameObject h in hearts) {
		            h.SetActive(false);
	            };
	            break;
            default:
                Debug.Log("Invalid amount of life: " + PlayerController.health);
                break;
        }

    }
}
