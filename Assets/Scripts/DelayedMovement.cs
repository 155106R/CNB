using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelayedMovement : MonoBehaviour {

    public float lerpValue = 0.01f;
    public Transform parentTransform;

    private Vector3 prevPosition;
    Vector3 localOffset;

    // Use this for initialization
    void Awake () {
        if (parentTransform == null)
            parentTransform = this.transform.parent;

        prevPosition = parentTransform.transform.position;
    }

    void Update()
    {
        localOffset += prevPosition - parentTransform.position;
        this.transform.localPosition = localOffset;
        localOffset = Vector3.Lerp(localOffset, new Vector3(), lerpValue);
    }
    void LateUpdate ()
    {
        prevPosition = parentTransform.position;
    }
}