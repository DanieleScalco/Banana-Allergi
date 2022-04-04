using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public GameObject canvasScores;
	public GameObject canvasInfo;
	public GameObject canvasMenu;

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
        CloseMenu();
    }

    public void CloseScore() {
	    canvasScores.SetActive(false);
        ShowMenu();
    }

    public void ShowInfo() {
        canvasInfo.SetActive(true);
        CloseMenu();
    }

    public void CloseInfo() {
	    canvasInfo.SetActive(false);
        ShowMenu();
    }


	private void ShowMenu() {
		canvasMenu.SetActive(true);
    }

	private void CloseMenu() {
        canvasMenu.SetActive(false);
	}
}
