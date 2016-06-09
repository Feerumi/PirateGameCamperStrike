using UnityEngine;
using System.Collections;

public class HouseMovement : MonoBehaviour {

	public float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		// Move the house equal to the determined speed along the X axis.
		this.transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));
	}
}
