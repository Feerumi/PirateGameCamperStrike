using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

/**
 * Governs  the action player can perform.
 * 
 * Namely hitting enemies.
 */ 
public class PlayerAction : MonoBehaviour, CollisionCallback.CollisionListener {

	/**
	 * Is an attack currently in progress.
	 */
	private bool Attacking = false;

	/**
	 * Contains a collection of objects currently residing within
	 * melee hitbox.
	 */
	private LinkedList<GameObject> collidingObjects;

	/**
	 * Interface used to track objects overlapping with meleehitbox.
	 */
	public CollisionCallback callback;

	/**
	 * Attack recharge time in seconds. Only invoked when attack
	 * is missed.
	 */
	public float AttackRecharge;

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
		collidingObjects = new LinkedList<GameObject>();
		if (callback != null)
			callback.setCollisionListener(this);
	}

	void Update () {
		if (Input.GetButtonDown ("PlayerAction") && !Attacking) {
			AttackDisable ();
			Debug.Log (collidingObjects.Count);

			// If player misses the target, re-enable attacking after a delay.
			if (collidingObjects.Count == 0) {
				Invoke ("AttackEnable", AttackRecharge);
				Image.fillAmount = 1.0f;
				// If the attack hits a target, re-enable attack immediatly and
				// remove damaged game objects.
			} else {

				// This abomination might start malfunctioning at some point!
				// Individually destroy all the game objects within players reach,
				foreach (GameObject gObject in collidingObjects) {
					Destroy (gObject);
				}
					
				collidingObjects.Clear ();
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

	/**
	 * Disables players ability to attack.
	 */
	private void AttackDisable() {
		Attacking = true;
	}

	/**
	 * Called when an enemy enters the players melee hitbox area.
	 */
	void CollisionCallback.CollisionListener.onCollisionEnter(Collider2D coll) {
		collidingObjects.AddLast (coll.gameObject);
	}

	/**
	 * Called when an enemy exits the players melee hitbox area.
	 */
	void CollisionCallback.CollisionListener.onCollisionExit(Collider2D coll) {
		collidingObjects.Remove (coll.gameObject);
	}
}
