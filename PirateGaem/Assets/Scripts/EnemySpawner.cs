using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class EnemySpawner : MonoBehaviour {

	public List<GameObject> enemies;
	float spawnInterval = 2f;
	bool playerNotDead = true;
	float minInterval = 0.4f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy());
	}

	public void ChangeIntervalTime() {
		if (spawnInterval >= minInterval) 
		{
			spawnInterval *= 0.95f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnEnemy() {
		while (playerNotDead) {
			yield return new WaitForSeconds (spawnInterval);
			Instantiate (enemies [Random.Range (0, enemies.Count)], transform.position, transform.rotation);
			ChangeIntervalTime ();
		}


	}
		
}
