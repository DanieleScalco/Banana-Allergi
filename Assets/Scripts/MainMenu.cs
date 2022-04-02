using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject canvasScores;

    // Start is called before the first frame update
    void Start() {
        //PlayerPrefs.DeleteAll();
    }

    // Update is called once per frame
    void Update() {
        
    }

    public void PlayGame() {
	    SceneManager.LoadScene("Game");
    }

    public void ShowScores() {
        canvasScores.SetActive(true);
    }
}
