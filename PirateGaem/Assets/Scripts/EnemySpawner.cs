using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject enemy;
	float spawnInterval = 2f;

	// Use this for initialization
	void Start () {
		StartCoroutine (SpawnEnemy());
	}

	public void ChangeIntervalTime() {
		if (spawnInterval >= 0.2f) 
		{
			spawnInterval *= 0.8f;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator SpawnEnemy() {
		while (true) {
			yield return new WaitForSeconds (spawnInterval);
			Instantiate (enemy, transform.position, transform.rotation);
			ChangeIntervalTime ();
		}


	}
		
}
