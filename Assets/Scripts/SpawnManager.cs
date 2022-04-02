using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour {

	public GameObject banana;
	public GameObject scoreText;
	public GameObject[] powerups;

	private float currentTime = 0;
	public float spawnTimeBanana = 2;
	private float whenSpawnTimeBanana;
	public int numberBananasSpawned = 2;
	private int timeToIncreaseBananas = 45;
	private int increaseSpeedBanana = 25;

	private float spawnTimeIncreaseDifficulty = 10;
	private float whenSpawnTimeIncreaseDifficulty;
	private float whenSpawnPowerups = 5.0f;

	public static int score = 0; // = time + bonusScore
	public static int bonusScore = 0;

	public static bool isGameOver = false;


	// Start is called before the first frame update
    void Start() {

	    whenSpawnTimeBanana = spawnTimeBanana;
	    whenSpawnTimeIncreaseDifficulty = spawnTimeIncreaseDifficulty;
    }

	// Update is called once per frame
	void Update() {

		if (!isGameOver) {

			currentTime += Time.deltaTime;

			// Spawn bananas
			if (currentTime >= whenSpawnTimeBanana) {
				for (int i = 0; i < numberBananasSpawned; i++) {
					SpawnBanana();
				}

				whenSpawnTimeBanana += spawnTimeBanana;
			}


			// Update score
			score = (int) (Mathf.Floor(currentTime * 100) + bonusScore);
			scoreText.GetComponent<Text>().text = scoreText.GetComponent<Text>().text.Substring(0, 7) + score;


			// Check if difficulty has to increase
			if (currentTime > whenSpawnTimeIncreaseDifficulty) {

				// Decrease spawn time
				if (spawnTimeBanana > 0.1f)
					spawnTimeBanana -= 0.1f;

				// Increase banana speed
				MoveBanana.force += increaseSpeedBanana;

				whenSpawnTimeIncreaseDifficulty += spawnTimeIncreaseDifficulty;
				if (whenSpawnTimeIncreaseDifficulty % timeToIncreaseBananas == 0) {
					numberBananasSpawned++;
				}

			}

			// Spawn powerups
			if (currentTime >= whenSpawnPowerups) {
				SpawnPowerup();
				whenSpawnPowerups += Random.Range(2.0f, 5.0f);
			}
		}

	}

	void SpawnBanana() {
	    Vector3 randomPosition = new Vector3(Random.Range(-18.5f, 18.5f), 15.5f, 0);
	    Vector3 randomRotationZ = new Vector3(0, 0, Random.Range(0, 360));
		Instantiate(banana, randomPosition, Quaternion.Euler(randomRotationZ));
    }

    void SpawnPowerup() {
	    Vector3 randomPosition = new Vector3(Random.Range(-18.5f, 18.5f), 15.5f, 0);
	    int indexPowerup = Random.Range(0, powerups.Length);	// Points has more chance to spawn cause there are more in the list
	    Instantiate(powerups[indexPowerup], randomPosition, powerups[indexPowerup].transform.rotation);
    }
}
