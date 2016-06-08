using UnityEngine;
using System.Collections;

public class HouseSpawner : MonoBehaviour {

	public GameObject House;

	public float spawnInterval;

	public float startDelay;

	public PropTextureLoader Proploader;

	private HouseMovement previousHouse;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (previousHouse != null) {
			float width = previousHouse.GetComponent<Renderer> ().bounds.size.x;
			float xPos = previousHouse.gameObject.transform.position.x;

			if (xPos + width <= this.transform.position.x) {
				SpawnHouse ();
			}
		} else {
			SpawnHouse ();
		}
	}

	void SpawnHouse() {
		House.GetComponent<SpriteRenderer>().sprite = Proploader.getRandomTexture();
		//previousHouse = (HouseMovement) Instantiate (House, this.transform.position, this.transform.rotation);
		GameObject go = (GameObject) (Instantiate (House, this.transform.position, this.transform.rotation));
		previousHouse = go.GetComponent<HouseMovement> ();
	}
}
