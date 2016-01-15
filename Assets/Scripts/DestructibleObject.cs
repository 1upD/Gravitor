using UnityEngine;
using System.Collections;

public class DestructibleObject : MonoBehaviour
{
    public GameObject self;
    public float health = 25.0f;
    public GameObject destructionParticlePrefab;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerStay(Collider other)
    {
        if (health > 0.0f && other.gameObject.name != self.name)
        {
            health -= 5.0f;
        }
        else
        {
            die();
        }


    }

    private void die()
    {
        GameObject g = (GameObject)Instantiate(destructionParticlePrefab,
                                                       transform.position,
                                                       Quaternion.identity);
        Destroy(self);
        Debug.Log("Destructible object has been destroyed.");
    }

}