using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
 * Governs  the action player can perform.
 * 
 * Namely hitting enemies.
 */ 
public class PlayerAction : MonoBehaviour {

	/**
	 * Is an attack currently in progress.
	 */
	private bool Attacking = false;

	/**
	 * Contains a collection of objects currently residing within
	 * melee hitbox.
	 */
	private static List<GameObject> enemies;

	/**
	 * Attack recharge time in seconds. Only invoked when attack
	 * is missed.
	 */
	public float AttackRecharge;

	private Animator am;

	/**
	 * Image used to display remaining cooldown.
	 */
	public GameObject CooldownImage;

	/**
	 * Area in which the enemies are destroyed upon player attack.
	 */
	private BoxCollider2D AttackHitBox;

	Image Image;

	void Start () {
		Image = CooldownImage.GetComponentInChildren<Image> ();

		Image.fillAmount = 0;
		enemies = new List<GameObject>();
	}

	void Update () {
		if (Input.GetButtonDown ("PlayerAction") && !Attacking) {
			Punch ();
			AttackDisable ();
			Debug.Log ("Hit:" + enemies.Count);

			// If player misses the target, re-enable attacking after a delay.
			if (enemies.Count == 0) {
				Invoke ("AttackEnable", AttackRecharge);
				Image.fillAmount = 1.0f;
				// If the attack hits a target, re-enable attack immediatly and
				// remove damaged game objects.
			} else {
				// This abomination might start malfunctioning at some point!
				// Individually destroy all the game objects within players reach,
				foreach (GameObject gObject in enemies) {
					Destroy (gObject);
				}
					
				enemies.Clear ();
				AttackEnable ();
			}
		} else if (Attacking) {
			Image.fillAmount -= Time.deltaTime / AttackRecharge;
		} else {
			Image.fillAmount = 0;
		}
	}

	/**
	 * Allows player to attack.
	 */
	private void AttackEnable() {
		Attacking = false;
	}

	private void Punch() {
		GetComponent<Animator> ().SetTrigger ("Punch");
	}
		
	/**
	 * Disables players ability to attack.
	 */
	private void AttackDisable() {
		Attacking = true;
	}

	public void inRange(GameObject obj) {
		enemies.Add (obj);
		Debug.Log ("inRange:" + enemies.Count);
	}

	public void outOfRange(GameObject obj) {
		enemies.Remove (obj);
		Debug.Log ("outOfRange" + enemies.Count);
	}
}
