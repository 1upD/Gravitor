using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreCounter : MonoBehaviour {

	private int points;
	private int displayedScore;
	public Text counterText;
	public string counterString = "Score";
	private bool isScoring = true;
	// Use this for initialization
	void Start () {
		points = 0;
	}

	// Update is called once per frame
	void Update () {
		if(isScoring) displayedScore = points + (int)(Time.time);
		counterText.text = counterString + ": " + displayedScore.ToString();
	}

	public void StopScoring(){
		isScoring = false;
	}

	public void AddPoints(int pointsToAdd){
		points += pointsToAdd;
	}
}
