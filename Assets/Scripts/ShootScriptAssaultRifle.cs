using UnityEngine;
using System.Collections;

public class ShootScriptAssaultRifle : MonoBehaviour
{
    // Source: http://noobtuts.com/unity/first-person-shooter-game

    // Rocket Prefab
    public GameObject rocketPrefab;
    
    // Name of weapon associated
    public string weaponObjectName = "CQAssaultRifle";
    
    // Does this weapon have burst fire?
    public bool canBurstFire = true;

    // Is this weapon in burst fire mode?
    private bool burstFire = false;

    private Animator rifleAnimator;

    void Start()
    {
        // Get the rifle animator
        rifleAnimator = GameObject.Find(weaponObjectName).GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // left mouse held down? rifle firing animation finished?
        if (Input.GetMouseButton(0) && !rifleAnimator.GetBool("Firing"))
        {
            // Toggle the firing animation
            rifleAnimator.SetBool("Firing", true);

            if (burstFire)
            {
                // Burst fire
                StartCoroutine(Burst());
            }
            else
            {
                Fire();
            }
            
        }

        // right mouse clicked? Has burst fire?
        if (Input.GetMouseButtonDown(1) && canBurstFire)
        {
            if (burstFire)
            {
                rifleAnimator.SetFloat("FiringSpeedMultiplier", 2);
                burstFire = false;
            }
            else
            {
                rifleAnimator.SetFloat("FiringSpeedMultiplier", 1);
                burstFire = true;
            }
        }
    }

    // Asynchronous method to fire three shots
    private IEnumerator Burst()
    {
        // Fire three times            
        Fire();
        yield return new WaitForSeconds(0.05f);
        Fire();
        yield return new WaitForSeconds(0.05f);
        Fire();
    }

    private void Fire()
    {
        // spawn rocket
        // - Instantiate means 'throw the prefab into the game world'
        // - (GameObject) cast is required because unity is stupid
        // - transform.position because we want to instantiate it exactly
        //   where the weapon is
        // - transform.parent.rotation because the rocket should face the
        //   same direction that the player faces (which is the weapon's
        //   parent.
        //   we can't just use the weapon's rotation because the weapon is
        //   always rotated like 45° which would make the bullet fly really
        //   weird
        GameObject g = (GameObject)Instantiate(rocketPrefab,
                                               transform.position,
                                               transform.parent.rotation);

        // make the rocket fly forward by simply calling the rigidbody's
        // AddForce method
        // (requires the rocket to have a rigidbody attached to it)
        float force = g.GetComponent<BulletController>().speed;
        g.GetComponent<Rigidbody>().AddForce(g.transform.forward * force);
    }
}
