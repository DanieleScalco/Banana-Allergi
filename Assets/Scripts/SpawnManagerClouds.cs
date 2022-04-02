using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerClouds : MonoBehaviour {

	public GameObject[] clouds;

	private float currentTime = 0;
	private float spawnTimeCloud = 1;

	// Start is called before the first frame update
    void Start() {

    }

	// Update is called once per frame
	void Update() {

		currentTime += Time.deltaTime;

		// Spawn clouds
		if (currentTime >= spawnTimeCloud) {
			SpawnCloud();
			spawnTimeCloud += Random.Range(7.0f, 9.0f);
		}

	}

    void SpawnCloud() {
	    int cloudIndex = Random.Range(0, clouds.Length);
	    Vector3 randomPosition = new Vector3(27.5f, Random.Range(-3.0f, 9.0f), 0);
	    Instantiate(clouds[cloudIndex], randomPosition, clouds[cloudIndex].transform.rotation);
    }

}
