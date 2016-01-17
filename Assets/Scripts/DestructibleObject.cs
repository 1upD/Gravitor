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

        Projectile projectile = other.gameObject.GetComponent<Projectile>();
        if (health > 0.0f && projectile != null)
        {
            health -= projectile.damage;
        }
        else if(projectile != null)
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