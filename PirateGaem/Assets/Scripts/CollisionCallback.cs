using UnityEngine;
using System.Collections;

public class CollisionCallback : MonoBehaviour {

	public CollisionListener listener;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (listener != null)
			listener.onCollisionEnter (other);
	}

	void OnTriggerExit2D(Collider2D other) {
		if (listener != null) 
			listener.onCollisionExit (other);
	}

	public void setCollisionListener(CollisionListener listener) {
		this.listener = listener;
	}

	public interface CollisionListener {
		void onCollisionEnter(Collider2D coll);
		void onCollisionExit(Collider2D coll);
	}
}
