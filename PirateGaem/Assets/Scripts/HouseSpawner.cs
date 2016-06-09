using UnityEngine;
using System.Collections;

public class HouseSpawner : MonoBehaviour {

	/**
	 * Object to spawn.
	 */
	public GameObject House;

	/**
	 * Collection of textures the spawned object might have,
	 */
	public PropTextureLoader Proploader;

	/**
	 * Last spawned house. Used to determine if a new one can be
	 * created without the objects overlapping.
	 */
	private GameObject previousHouse;

	/**
	 * Main camera.
	 */
	public Camera camera;

	// Use this for initialization
	void Start () {
	
		// X coordinate of the edge of the screen.
		float x = camera.ScreenToWorldPoint (new Vector3 (0, 0, 0)).x;
		float width = House.GetComponent<Renderer> ().bounds.size.x;

		// Populate the are between the edge of the screen and the spawner
		// with houses.
		do {
			House.GetComponent<SpriteRenderer>().sprite = Proploader.getRandomTexture();
			previousHouse = (GameObject) (Instantiate (House, 
														new Vector3(x,
																	this.transform.position.y,
																	this.transform.position.z), 
														this.transform.rotation
			));
			x += width;
		} while(previousHouse.transform.position.x + width <= this.transform.position.x);
	}
	
	// Update is called once per frame
	void Update () {
		// Determine if the last spawned house is far enough away so that a new
		// object can be spawned without overlap.
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

	/**
	 * Spawns a new game object at the spawners location.
	 */
	void SpawnHouse() {
		House.GetComponent<SpriteRenderer>().sprite = Proploader.getRandomTexture();
		 previousHouse = (GameObject) (Instantiate (House, this.transform.position, this.transform.rotation));
	}
}
