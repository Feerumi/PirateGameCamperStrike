using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class RumLevel : MonoBehaviour {
	
	int rumLevel = 5;
	int minRum = 0;
	int maxRum = 5;
	public Sprite[] sprites;
	Sprite currentSprite;

	public void Start(){
		currentSprite = (Sprite) gameObject.GetComponent<Image>().sprite;
	}

	public void Update(){

		if (rumLevel == 0) {

			Application.LoadLevel ("gameover");

		}

	}

	void rumInLimits(int amount){
				
		if ((minRum <= (rumLevel + amount)) && ((rumLevel + amount) <= maxRum)) {
			rumLevel += amount;
			currentSprite = sprites[rumLevel];
			gameObject.GetComponent<Image>().sprite = currentSprite;
		}

	}

	public void addRum(){
		rumInLimits(1);
	}

	public void subtractRum(){
		rumInLimits(-1);
	}

}
