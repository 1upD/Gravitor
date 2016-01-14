using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Counter : MonoBehaviour {
    public Text counterText;
    float set_seconds = 100;
    public float seconds;

	// Use this for initialization
	void Start () {
        counterText = GetComponent<Text>() as Text;
	}
	
	// Update is called once per frame
	void Update () {
        seconds = set_seconds - (int)(Time.time % 60f);
        counterText.text = "Time : " + seconds.ToString("000");
        if (seconds < 90) changeTimeColor();
	}

    public void changeTimeColor() {
        counterText.color = Color.red;
    }
}
