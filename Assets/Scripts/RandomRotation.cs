using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
	LevelRotate script;
	public float timeBetweenRotations = 60.0f;
	private bool isWaiting = false;
	// Use this for initialization
	void Start () {
		script = GetComponent<LevelRotate>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWaiting) {
			//StartCoroutine (TimedRotate());
		}
	}

	private IEnumerable TimedRotate(){
		yield return new WaitForSeconds(timeBetweenRotations);
		script.beginRotation();
	}
}
