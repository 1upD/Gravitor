using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainMenuController : MonoBehaviour {

    public GameObject StartButton;
    public GameObject QuitButton;
    private Button startButton;
    private Button quitButton;

	// Use this for initialization
	void Start () {
        startButton = StartButton.GetComponent<Button>();
        quitButton = QuitButton.GetComponent<Button>();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnStartPressed()
    {
        Application.LoadLevel(1);
    }

    public void OnQuitPressed(){
        Application.Quit();
    }
}
