using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnSeenEvent : EventBase
{
    private Collider thisTrigger;
    
    private void Awake()
    {
        thisTrigger = this.GetComponent<Collider>();
        if (thisTrigger == null || thisTrigger.isTrigger == false)
            Destroy(this);
    }

    // Update is called once per frame
    void Update()
    {
        Transform head = Player.Instance.head.transform;
        Ray ray = new Ray(head.position, head.forward);
        RaycastHit hit;
        if (thisTrigger.Raycast(ray, out hit, 10.0f))
        {
            Trigger();
        }
    }
}