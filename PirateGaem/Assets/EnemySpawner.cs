using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour {

	public GameObject Enemy;

	// Use this for initialization
	void Start () {
		SpawnEnemy ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void SpawnEnemy() {
		Instantiate (Enemy);
	}
}
