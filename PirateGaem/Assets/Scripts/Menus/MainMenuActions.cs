using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour {

	public GameObject playButton;
	public GameObject exitButton;
	public GameObject logoText;
	public GameObject characterMenu;
	bool moveAnimations = false;
	float speed = 500;

	void Start(){
		
	}

	public void onPlay(){
		moveAnimations = true;
		playButton.SetActive (false);
		exitButton.SetActive (false);
		Invoke ("OnFinishedPlayFade", 2);
	}
	public void onExit(){
		Application.Quit();
	}

	void Update(){
		if (moveAnimations) {
			characterMenu.transform.Translate(new Vector3(Time.deltaTime * speed, 0,0));
			logoText.transform.Translate (new Vector3 (0, Time.deltaTime * speed/2, 0));
		}
	}

	void OnFinishedPlayFade(){
		SceneManager.LoadScene(1);
	}

	public void onHoverPlay(){
		playButton.transform.localScale += new Vector3 (0.1F, 0.1F, 0);
	}

	public void onHoverExit(){
		exitButton.transform.localScale += new Vector3 (0.1F, 0.1F, 0);
	}

	public void offHoverPlay(){
		playButton.transform.localScale -= new Vector3 (0.1F, 0.1F, 0);

	}
	public void offHoverExit(){
		exitButton.transform.localScale -= new Vector3 (0.1F, 0.1F, 0);
	}
}
