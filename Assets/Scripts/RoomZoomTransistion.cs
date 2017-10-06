using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomZoomTransistion : RoomTransistion {

    public float translationOffset;
    public float scaleOffset;

    public float translateTime;
    public float scaleTime;

    private List<Vector3> originalPositionList = new List<Vector3>();
    private List<Vector3> originalScaleList = new List<Vector3>();
    private List<Vector3> directionList = new List<Vector3>();

    private int stepDirection = 1;//should strictly only be 1 or -1

    private float translationStep = -0.5f;
    private float translationStepSpeed;
    
    private float scaleStep = -0.5f;
    private float scaleStepSpeed;
    
    void Start()
    {
        foreach (Transform transform in roomObjectList)
        {
            originalPositionList.Add(transform.localPosition);
            originalScaleList.Add(transform.localScale);

            Vector3 dir = new Vector3(0, 0, 0);
            dir = transform.localPosition;
            if(Mathf.Abs(dir.x) > Mathf.Abs(dir.z))
            {
                dir.z = 0;
                if (dir.x > 0)
                    dir.x = 1;
                else
                    dir.x = -1;
            }
            else
            {
                dir.x = 0;
                if (dir.z > 0)
                    dir.z = 1;
                else
                    dir.z = -1;
            }
            dir.y = 0;
            directionList.Add(dir);
        }

        translationStepSpeed = 1.0f / translateTime;
        scaleStepSpeed = 1.0f / scaleTime;
    }

    // Update is called once per frame
    void Update()
    {
        if (transistionComplete)
            return;

        //Handles translation step calculations
        translationStep += translationStepSpeed * stepDirection * Time.deltaTime;
        if (translationStep * stepDirection >= 0.5f)
        {
            translationStep = 0.5f * stepDirection;
        }
        //Handles scale step calculations
        scaleStep += scaleStepSpeed * stepDirection * Time.deltaTime;
        if (scaleStep * stepDirection >= 0.5f)
        {
            scaleStep = 0.5f * stepDirection;
        }

        if (translationStep * stepDirection >= 0.5f &&
            scaleStep * stepDirection >= 0.5f
            )
        {
            if (stepDirection > 0)
                OnEnterComplete.Invoke();
            else
                OnExitComplete.Invoke();

            transistionComplete = true;
        }

        for (int i = 0; i < roomObjectList.Count; ++i)
        {
            roomObjectList[i].localPosition = originalPositionList[i] + (directionList[i] * translationOffset * (translationStep + 0.5f));
            Vector3 scaleDir = directionList[i];
            scaleDir.x = Mathf.Abs(scaleDir.x);
            scaleDir.z = Mathf.Abs(scaleDir.z);
            roomObjectList[i].localScale = originalScaleList[i] + (scaleDir * scaleOffset * (scaleStep + 0.5f));
        }
    }

    public override void Enter()
    {
        base.Enter();

        translationStep = 0.5f;
        scaleStep = 0.5f;
        stepDirection = -1;
    }
    public override void Exit()
    {
        base.Exit();

        translationStep =-0.5f;
        scaleStep =-0.5f;
        stepDirection = 1;
    }
}