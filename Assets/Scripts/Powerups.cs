using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Powerups : MonoBehaviour {

	private AudioSource audioSource;
	public AudioClip audioClip;

	// Start is called before the first frame update
    void Start() {
		
	    audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update() {
        
    }

	private void OnCollisionEnter2D(Collision2D collision) {
		
		if (collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
		} else if (collision.gameObject.CompareTag("Player")) {

			PlayerController playerControllerScript = GameObject.Find("Monkey").GetComponent<PlayerController>();
			SpawnManager.bonusScore += 50;
			playerControllerScript.audioSource.PlayOneShot(audioClip, name.Contains("G")? 0.4f : 1);

			if (name.Contains("Points")) {
				SpawnManager.bonusScore += 450; // + 50 for every bonus
			} else if (name.Contains("Explosion")) {
				playerControllerScript.ActivateExplosion();
			} else if (name.Contains("G")) {
				if (PlayerController.health < 3)
					PlayerController.health++;
			}

			Destroy(gameObject);
		}
	}


}
