using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventBase : MonoBehaviour {

    public UnityEvent eventToTrigger;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	}

    public virtual void Trigger()
    {
        eventToTrigger.Invoke();
    }
}
