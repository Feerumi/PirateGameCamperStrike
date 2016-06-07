using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class MainMenuActions : MonoBehaviour {

	public void onPlay(){
		SceneManager.LoadScene(1);
	}
	public void onExit(){
		Application.Quit();
	}
}
