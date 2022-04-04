using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreTableMenu : MonoBehaviour {

	private List<string> playerName;
	private List<int> playerScore;
	private List<Transform> children;

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

}
