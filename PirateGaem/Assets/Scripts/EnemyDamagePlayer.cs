using UnityEngine;
using System.Collections;

public class EnemyDamagePlayer : MonoBehaviour {

	/**
	 * Entity which the Enemy can damage.
	 */ 
	public PlayerLife player;

	/**
	 * The amount of damage that is applied to the player.
	 */
	public float Damage;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag.Equals(player.gameObject.tag)) {
			player.DamagePlayer (Damage);
		}
	}
}
