using UnityEngine;
using System.Collections;

public class InteractPickupRifle : MonoBehaviour {

    Interact interact;

    // Use this for initialization
    void Start()
    {
        interact = GetComponent<Interact>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.OnInteract())
        {
            GameObject g = GameObject.Find("RifleMuzzle");
            ShootScriptAssaultRifle script = g.GetComponent<ShootScriptAssaultRifle>();
            script.hasWeapon = true;
            script.currentWeapon = true;
            Destroy(transform.gameObject);

        }

    }
}
