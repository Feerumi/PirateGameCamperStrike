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

	void OnCollisionEnter2D (Collision2D col)
	{
		Debug.Log (col.gameObject.tag);

		if (col.gameObject.tag == "Player") {
			Destroy (this.gameObject);
		}
	}
}
