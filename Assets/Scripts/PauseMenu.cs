using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PauseMenu : MonoBehaviour {

	Text mutetext;
    GameObject pauseMenu;
    bool paused;
    bool muted;

	// Use this for initialization
	void Start () {
		paused = false;
		pauseMenu = GameObject.Find ("pauseMenu");
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;
		}

		if (paused) {
			Debug.Log ("pause");
			pauseMenu.SetActive (true);
			Time.timeScale = 0;
		} else if (!paused) {
			pauseMenu.SetActive (false);
			Time.timeScale = 1;
		}

		if (muted) {
			AudioListener.volume = 0;
			mutetext.text = "Unmute";
		} else if (!muted) {
			AudioListener.volume = 1;
			mutetext.text = "Mute";
		}

	}

	public void Resume(){
		paused = false;
	}

	public void MainMenu(){
		Application.LoadLevel(0);
	}

	public void Save(){
		PlayerPrefs.SetInt("currentscenesave", Application.loadedLevel);
	}

	public void Load(){
		Application.LoadLevel(PlayerPrefs.GetInt ("currentscenesave"));
	}

	public void Quit(){
		Application.Quit();
	}

	public void Mute(){
		muted = !muted;
	}
}

