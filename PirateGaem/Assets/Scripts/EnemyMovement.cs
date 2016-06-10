using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	private float minSpeed = -0.3f;

	private float maxSpeed = -1.1f;

	private float speed;
	public PlayerAction player;

	// Use this for initialization
	void Start () {
		speed = (float) (Random.Range (minSpeed, maxSpeed));
	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == (player.tag))
			player.inRange (this.gameObject);
	}


	void OnTriggerExit2D(Collider2D other) {
		if (other.tag == (player.tag))
			player.outOfRange (this.gameObject);
	}
}
