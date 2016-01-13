using UnityEngine;
using System.Collections;

public class Interact : MonoBehaviour {

    private bool onInteract;

	// Use this for initialization
	void Start () {
        onInteract = false;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void OnLookEnter()
    {
        onInteract = true;
    }

    // Method used by other scripts to see if this object is being interacted with
    public bool OnInteract() {
    if (onInteract){
        onInteract = false;
        return true;
    }
    else
    {
        return false;
    }
    }

}
