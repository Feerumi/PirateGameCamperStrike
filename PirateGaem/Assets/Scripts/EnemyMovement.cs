using UnityEngine;
using System.Collections;

public class EnemyMovement : MonoBehaviour {

	float speed = -1;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		this.transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag.Equals("Player")) {
			// TODO Delete when off screen.
			//Destroy (this.gameObject);
		}
	}
}
