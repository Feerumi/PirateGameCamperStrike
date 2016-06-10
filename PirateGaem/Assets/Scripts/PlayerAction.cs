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
	 * Amount of points in score text
	 */
	private float scorePoints;

	/**
	 * Chance to get more rum
	 */
	private float chanceOfRum = 10;

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

	/**
	 * UI Score text
	 */
	public Text ScoreText;

	/**
	 * UI Rum bottle
	 */
	public RumLevel rumBottle;

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

			// If player misses the target, re-enable attacking after a delay.
			if (enemies.Count == 0) {
				Invoke ("AttackEnable", AttackRecharge);
				Image.fillAmount = 1.0f;
				calculateRum (-1);
				// If the attack hits a target, re-enable attack immediatly and
				// remove damaged game objects.
			} else {
				// This abomination might start malfunctioning at some point!
				// Individually destroy all the game objects within players reach,
				foreach (GameObject gObject in enemies) {
					Destroy (gObject);
					calculateRum (1);
				}

				scorePoints += enemies.Count;
				enemies.Clear ();
				AttackEnable ();
				ScoreText.text = "" + scorePoints;
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

	private void calculateRum(int amount){

		switch(amount){

		case 1:
			float random = Random.Range (0, 100);
			if (random > 100 - chanceOfRum) {
				rumBottle.addRum ();
			}
			break;
		case -1:
			rumBottle.subtractRum ();
			break;
		}
	}

	public void inRange(GameObject obj) {
		enemies.Add (obj);
	}

	public void outOfRange(GameObject obj) {
		enemies.Remove (obj);
	}
}
