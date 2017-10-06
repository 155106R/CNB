using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAction : MonoBehaviour {
    
    public Vector3 translationOffset;
    public Vector3 rotationOffset;
    public Vector3 scaleOffset;

    public float translateTime;
    public float rotateTime;
    public float scaleTime;
    public bool bounceBack;
    public int repeatCount;

    private Vector3 originalPosition;
    private Vector3 originalRotation;
    private Vector3 originalScale;

    private int stepDirection = 1;//should strictly only be 1 or -1

    /*
     * Step values will be calculated as between -0.5f and 0.5f (to make bouncing easier)
     * When setting transform values, Step values will have an additional 0.5f offset so it will be between 0.5f and 1.0f
     * */

    private float translationStep = -0.5f;
    private float translationStepSpeed;

    private float rotationStep = -0.5f;
    private float rotationStepSpeed;

    private float scaleStep = -0.5f;
    private float scaleStepSpeed;

    private bool isRunning;

    // Use this for initialization
    void Awake()
    {
        isRunning = false;

        stepDirection = 1;

        originalPosition = this.transform.localPosition;
        originalRotation = this.transform.localEulerAngles;
        originalScale = this.transform.localScale;

        translationStepSpeed = 1.0f / translateTime;
        rotationStepSpeed = 1.0f / rotateTime;
        scaleStepSpeed = 1.0f / scaleTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRunning)
            return;

        //Handles translation step calculations
        translationStep += translationStepSpeed * stepDirection * Time.deltaTime;
        if (translationStep * stepDirection >= 0.5f)
        {
            translationStep = 0.5f * stepDirection;
        }
        //Handles rotation step calculations
        rotationStep += rotationStepSpeed * stepDirection * Time.deltaTime;
        if (rotationStep * stepDirection >= 0.5f)
        {
            rotationStep = 0.5f * stepDirection;
        }
        //Handles scale step calculations
        scaleStep += scaleStepSpeed * stepDirection * Time.deltaTime;
        if (scaleStep * stepDirection >= 0.5f) 
        {
            scaleStep = 0.5f * stepDirection;
        }

        if (translationStep * stepDirection >= 0.5f &&
            rotationStep * stepDirection >= 0.5f &&
            scaleStep * stepDirection >= 0.5f
            )
        {
            if (bounceBack && stepDirection > 0.0f)
            {
                stepDirection = -stepDirection;
            }
            else if (repeatCount > 0)
            {
                translationStep = -0.5f;
                rotationStep = -0.5f;
                scaleStep = -0.5f;

                stepDirection = 1;
                --repeatCount;
            }
            else
                isRunning = false;
        }

        this.transform.localPosition = originalPosition + (translationOffset * (translationStep + 0.5f));
        this.transform.localEulerAngles = originalRotation + (rotationOffset * (rotationStep + 0.5f));
        this.transform.localScale = originalScale + (scaleOffset * (scaleStep + 0.5f));
    }
    
    public void RunAction()
    {
        isRunning = true;
    }

    void OnDrawGizmosSelected()
    {
        if (isRunning)
            return;

        Color gizmoColor = Color.yellow;
        //gizmoColor.a = 0.7f;

        Gizmos.color = gizmoColor;
        Quaternion rotation = Quaternion.Euler(rotationOffset.x, rotationOffset.y, rotationOffset.z);
        Gizmos.DrawMesh(
            this.GetComponent<MeshFilter>().sharedMesh,
            this.transform.position + translationOffset,
            Quaternion.Euler(this.transform.eulerAngles + rotationOffset),
            this.transform.localScale + scaleOffset
            );
    }
}
