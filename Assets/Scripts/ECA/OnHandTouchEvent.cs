using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OnHandTouchEvent : EventBase {

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
    }

    private void OnTriggerEnter(Collider other)
    {
        Transform leftArm = Player.Instance.leftArm.transform;
        Transform rightArm = Player.Instance.rightArm.transform;

        if (other.transform == leftArm ||
            other.transform == rightArm)
        {
            Trigger();
        }
    }
}