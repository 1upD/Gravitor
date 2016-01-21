using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public GameObject healthObject;
	public GameObject canvas;
    public Text counterText;
    public string counterString = "Reactor A";
    public float maxSeconds = 300;
    float set_seconds;
    public float seconds;

	private MusicManager musicManager;
    private Health healthScript;

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
        set_seconds = maxSeconds;
        seconds = set_seconds;
        healthScript = healthObject.GetComponent<Health>();
		musicManager = canvas.GetComponent<MusicManager> ();
	}
	
	// Update is called once per frame
	void Update () {
        if (seconds > 0)
        {
			seconds = set_seconds - (int)(Time.time);
            counterText.text = counterString + ": " + seconds.ToString("000");
			if (seconds < 90) {
				musicManager.audioTrackIndex = 2;

			}

			if (seconds < 60) {
				changeTimeColor ();
				playAlarm ();
			}
        }
        else
        {
            gameOver();
        }
	}

    private void gameOver()
    {
        healthScript.SetGameOver(true);
    }

    public void changeTimeColor() {
        counterText.color = Color.red;
    }

    public void resetTimer()
    {
		Debug.Log ("resetTimer works");
		// Never rest if at maximum
		if (seconds < maxSeconds) {
			set_seconds += maxSeconds - seconds;
			counterText.color = Color.white;
			musicManager.audioTrackIndex = 0;
		}
    }

	public void playAlarm(){
		AudioSource audioSource = GetComponent<AudioSource> ();
		if (!audioSource.isPlaying) {			
			audioSource.Play ();
		} 
	}

}
