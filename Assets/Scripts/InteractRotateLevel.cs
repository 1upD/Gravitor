using UnityEngine;
using System.Collections;

public class InteractRotateLevel : MonoBehaviour {

    Interact interact;

	// Use this for initialization
	void Start () {
        interact = GetComponent<Interact>();
	}
	
	// Update is called once per frame
	void Update () {
        if (interact.OnInteract())
        {
            GameObject level = GameObject.Find("Rotating Level");
            LevelRotate script = level.GetComponent<LevelRotate>();
            script.beginRotation();
        }
	    
	}
}
