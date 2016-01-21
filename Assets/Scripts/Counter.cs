using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public GameObject healthObject;
    public Text counterText;
    public string counterString = "Reactor A";
    public float maxSeconds = 300;
    float set_seconds;
    public float seconds;

    private Health healthScript;

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
        set_seconds = maxSeconds;
        seconds = set_seconds;
        healthScript = healthObject.GetComponent<Health>();
	}
	
	// Update is called once per frame
	void Update () {
        if (seconds > 0)
        {
			seconds = set_seconds - (int)(Time.time);
            counterText.text = counterString + ": " + seconds.ToString("000");
			if (seconds < 90) {
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
		}
    }

	public void playAlarm(){
		AudioSource audioSource = GetComponent<AudioSource> ();
		if (!audioSource.isPlaying) {			
			audioSource.Play ();
		} 
	}

}
