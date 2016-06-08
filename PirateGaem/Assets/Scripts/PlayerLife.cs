using UnityEngine;
using System.Collections;

/**
 * Governs how player gains or loses hitpoints.
 */
public class PlayerLife : MonoBehaviour {

	/**
	 * Number of hitpoints player has.
	 */
	public float Hitpoints;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	/**
	 * Damages player equal to the parameters absolute value.
	 */
	public void DamagePlayer(float Damage) {
		Hitpoints -= Mathf.Abs (Damage); 
	}

	/**
	 * Heals player equal to the parameters absolute value.
	 */
	public void HealPlayer(float Heal) {
		Hitpoints += Mathf.Abs (Heal);
	}
}
