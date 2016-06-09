using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	float speed = -1;
	// Use this for initialization

	public PlayerAction player;

	void Start () {

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
