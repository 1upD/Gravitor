using UnityEngine;
using System.Collections;

public class BugFollowController : MonoBehaviour {

    public GameObject target;
    public float force = 500;
	// Use this for initialization
	void Start () {
        transform.LookAt(target.transform.position);	
	}
	
	// Update is called once per frame
	void Update () {
        transform.LookAt(target.transform.position);
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Force);

		// Calculate distance to player
		float distToTarget = Vector3.Distance(transform.position, target.transform.position);
		if (distToTarget < 5) {
			AudioSource audioSource = GetComponent<AudioSource> ();
			audioSource.Play ();
		}
	}
}
