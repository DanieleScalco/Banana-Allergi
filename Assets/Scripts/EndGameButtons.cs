using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameButtons : MonoBehaviour {

    // Start is called before the first frame update
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        
    }

    public void RestartGame() {
	    // Static variables need to be reset
	    ResetStaticFields();
	    SceneManager.LoadScene("Game");
    }

    private static void ResetStaticFields() {
	    SpawnManager.isGameOver = false;
	    SpawnManager.bonusScore = 0;
	    SpawnManager.score = 0;
	    PlayerController.health = 3;
	    MoveBanana.force = 500;
    }

    public void ReturnMainMenu() {
        ResetStaticFields();
	    SceneManager.LoadScene("MainMenu");
    }
}
