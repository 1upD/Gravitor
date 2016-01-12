using UnityEngine;
using System.Collections;

public class LevelRotate : MonoBehaviour {
    public float rotationSpeed = 0.01f;
    public float timeBetweenRotations;
    public bool isRotating = true;
    private float velocity = 0;
    private float currentAngle;
    private float startRotationAngle;
    private float iterator = 0;
    // Use this for initialization
	void Start () {
        currentAngle = transform.rotation.z;
        beginRotation();
	}

    void beginRotation()
    {
        startRotationAngle = currentAngle;
    }

	// Update is called once per frame
	void Update () {
        currentAngle = transform.eulerAngles.z;
        if(isRotating){
            if (currentAngle < startRotationAngle + 45)
            {
                iterator += 1.0f * rotationSpeed;
            }
            else if (currentAngle < startRotationAngle + 90)
            {
                iterator -= 1.0f * rotationSpeed;            }
            else
            {
                velocity = 0;
                beginRotation();

            }
            velocity = iterator * iterator * rotationSpeed;
            transform.eulerAngles = new Vector3(0, 0, currentAngle + (velocity * rotationSpeed));

        }
	}
}
