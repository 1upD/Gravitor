using UnityEngine;
using System.Collections;

public class RandomRotation : MonoBehaviour {
	LevelRotate script;
	public float minTimeBetweenRotations = 45.0f;
    public float maxTimeBetweenRotations = 120.0f;
	private bool isWaiting = false;
	// Use this for initialization
	void Start () {
		script = GetComponent<LevelRotate>();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isWaiting) {
            isWaiting = true;
            StartCoroutine(TimedRotate());
		}
	}

	private IEnumerator TimedRotate(){
        float timeBetweenRotations = Random.Range(minTimeBetweenRotations, maxTimeBetweenRotations);
		yield return new WaitForSeconds(timeBetweenRotations);
		script.beginRotation();
        isWaiting = false;
	}
}
