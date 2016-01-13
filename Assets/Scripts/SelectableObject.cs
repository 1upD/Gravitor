using UnityEngine;
using System.Collections;

public class SelectableObject : MonoBehaviour {

    public float MaxSelectDistance = 0.8f;
    public KeyCode selectKey = KeyCode.E;
    public RaycastHit hit;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
    void Update()
    {
        if (Input.GetKey(selectKey))
        {
            // Create a ray from the camera
            Ray ray = Camera.main.ScreenPointToRay(new Vector3(Screen.width / 2, Screen.height / 2, 0));

            // The ray collides with an object
            // (Save the object to out parameter 'hit')
            if (Physics.Raycast(ray, out hit, 10))
            {
                // Store the interact script of the object that was hit
                Interact hitInteract = hit.collider.gameObject.GetComponent<Interact>();
                // If it has an interact script
                if (hitInteract != null)
                {
                    // Check if the object is in range
                    if (hit.distance < MaxSelectDistance)
                    {
                        // Call the method to execute on-interact behavior
                        hitInteract.OnLookEnter();

                    }
                }
            }

        }
    }
}
