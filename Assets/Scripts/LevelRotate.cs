using UnityEngine;
using System.Collections;

public class LevelRotate : MonoBehaviour {
    public float rotationSpeed = 0.01f;
    public float timeBetweenRotations;
    public bool isRotating = true;
    private float velocity = 0;
    private float currentAngle;
    private float startRotationAngle;
    private float velocity_iterator = 0;
    // Use this for initialization
	void Start () {
        currentAngle = transform.rotation.z;
        if (isRotating)
        {
            beginRotation();
        }
	}

    public void beginRotation()
    {
        if (!isRotating)
        {
            startRotationAngle = currentAngle;
            isRotating = true;
            
        }
    }

	// Update is called once per frame
	void Update () {
        // If this level should currently rotate:
        if(isRotating){
            // Get the current angle of rotation
            currentAngle = transform.eulerAngles.z;
            // Check edge case: Make sure that the angle hasn't crossed 359 degrees and reverted to 0
            if (currentAngle == 0 && startRotationAngle == 270)
            {
                velocity = 0;
                isRotating = false;
            }
            // If the rotation is less than halfway complete, increase the velocity by one
            if (currentAngle < startRotationAngle + 45)
            {
                velocity_iterator += 1.0f * rotationSpeed;
            }
            // If the rotation is more than halfway complete but not complete, decrease the velocity by one
            else if (currentAngle > startRotationAngle && currentAngle < startRotationAngle + 90)
            {
                velocity_iterator -= 1.0f * rotationSpeed;            }
            // If rotation is complete, set velocity to 0 and set the bool flag isRotating to false to end rotation
            else
            {
                velocity = 0;
                isRotating = false;

            }
            // Square the velocity
            velocity = velocity_iterator * velocity_iterator * rotationSpeed;
            // Rotate
            transform.eulerAngles = new Vector3(0, 0, currentAngle + (velocity * rotationSpeed));

        }
	}
}
