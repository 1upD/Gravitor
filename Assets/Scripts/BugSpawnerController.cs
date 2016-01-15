using UnityEngine;
using System.Collections;

public class BugSpawnerController : MonoBehaviour {
    public GameObject bugPrefab;
    public GameObject target;
    public float minTimeBetweenRotations = 5.0f;
    public float maxTimeBetweenRotations = 30.0f;
    private bool isWaiting = false;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!isWaiting)
        {
            isWaiting = true;
            StartCoroutine(TimedSpawn());
        }
    }

    private IEnumerator TimedSpawn()
    {
        float timeBetweenRotations = Random.Range(minTimeBetweenRotations, maxTimeBetweenRotations);
        yield return new WaitForSeconds(timeBetweenRotations);
        spawn();
        isWaiting = false;
    }

    private void spawn()
    {
        GameObject g = (GameObject)Instantiate(bugPrefab,
                                               transform.position,
                                               transform.parent.rotation);
        g.GetComponent<BugFollowController>().target = target;
    }
}
