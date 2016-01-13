using UnityEngine;
using System.Collections;

public class InteractPickupRifle : MonoBehaviour {

    Interact interact;
    public string weaponMuzzle = "RifleMuzzle";


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
            GameObject g = GameObject.Find(weaponMuzzle);
            ShootScriptAssaultRifle script = g.GetComponent<ShootScriptAssaultRifle>();
            script.hasWeapon = true;
            ShootScriptAssaultRifle.PutAwayAll();
            script.currentWeapon = true;
            Destroy(transform.gameObject);

        }

    }
}
