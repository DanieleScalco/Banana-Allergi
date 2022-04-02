using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTable : MonoBehaviour {

	private List<string> playerName;
	private List<int> playerScore;
	private List<Transform> children;

	private int index;

	public GameObject newRecord;
	public GameObject endGameButtons;

	// Start is called before the first frame update
	void Start() {

		// Get the single lines of the score
	    children = new List<Transform>();
	    foreach (Transform child in transform) {
		    if (child.name.Contains("PlayerScore")) {
			    children.Add(child);
		    }
	    }

	    playerName = new List<string>(children.Count + 1);
	    playerScore = new List<int>(children.Count + 1);

		LoadScores();
		AddPlayerCurrentScore();
		WriteScoresOnBoard();

	}

    // Update is called once per frame
    void Update() {

    }

    private void LoadScores() {

	    for (int i = 1; i <= children.Count; i++) {
		    
		    if (PlayerPrefs.HasKey("PlayerName" + i)) {
			    playerName.Add(PlayerPrefs.GetString("PlayerName" + i));
		    } else {
			    playerName.Add("Player");
		    }

		    if (PlayerPrefs.HasKey("PlayerScore" + i)) {
			    playerScore.Add(PlayerPrefs.GetInt("PlayerScore" + i));
		    } else {
			    playerScore.Add(0);
		    }

	    }

    }

    private void AddPlayerCurrentScore() {


	    playerScore.Add(SpawnManager.score);
	    playerScore = playerScore.OrderByDescending(x => x).ToList();

	    index = playerScore.IndexOf(SpawnManager.score);

	    // If the score is the last do nothing
	    if (index == playerScore.Count - 1) {
			return;
	    } else {

			newRecord.SetActive(true);
			endGameButtons.SetActive(false);

		    playerName.Insert(index, "Your name");

		    playerName.RemoveAt(playerName.Count - 1);

		    Transform pointerChild = children[index].Find("Pointer");
		    pointerChild.gameObject.SetActive(true);
		}
		
	    playerScore.RemoveAt(playerScore.Count - 1);

    }

	private void WriteScoresOnBoard() {

	    for (int i = 1; i <= children.Count; i++) {
		    Transform name = children[i - 1].Find("Name");
		    Text textName = name.gameObject.GetComponent<Text>();
		    Transform score = children[i - 1].Find("Score");
		    Text textScore = score.gameObject.GetComponent<Text>();
		    textName.text = playerName[i - 1];
		    textScore.text = string.Format("{0:0000000000}", playerScore[i - 1]);
	    }
    }

	// Method for saveButton
    public void SaveName() {
	    
	    // Update scoreTable, playerName and activate Pointer
	    if (index < playerScore.Count) {

			InputField inputField = newRecord.GetComponentInChildren<InputField>();
		    Transform nameChild = children[index].Find("Name");
		    Text textName = nameChild.gameObject.GetComponent<Text>();
		    string name = inputField.text;
		    textName.text = name;
		    playerName[index] = name;
	    }

		newRecord.SetActive(false);
		endGameButtons.SetActive(true);

	    SaveScores();
    }

    private void SaveScores() {

	    for (int i = 1; i <= children.Count; i++) {

			PlayerPrefs.SetString("PlayerName" + i, playerName[i - 1]);
			PlayerPrefs.SetInt("PlayerScore" + i, playerScore[i - 1]);
		    PlayerPrefs.Save();
	    }
	}

}
