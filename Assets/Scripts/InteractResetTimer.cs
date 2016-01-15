using UnityEngine;
using System.Collections;

public class InteractResetTimer : MonoBehaviour
{
    Interact interact;
    Counter counter;
    public GameObject timerText;
    
    // Use this for initialization
    void Start()
    {
        interact = GetComponent<Interact>();
        counter = timerText.GetComponent<Counter>();
    }

    // Update is called once per frame
    void Update()
    {
        if (interact.OnInteract())
        {
            counter.resetTimer();
			Debug.Log ("resetTimer()");
        }

    }
}
