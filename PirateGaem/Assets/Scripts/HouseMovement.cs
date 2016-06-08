using UnityEngine;
using System.Collections;

public class HouseMovement : MonoBehaviour {

	public float speed;
	private bool moving = true;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (moving)
			this.transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));
	}

	public void setMoving(bool moving) {
		this.moving = moving;
	}
}
