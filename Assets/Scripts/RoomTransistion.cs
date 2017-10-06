using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class RoomTransistion : MonoBehaviour
{
    public UnityEvent OnEnter;
    public UnityEvent OnEnterComplete;
    public UnityEvent OnExit;
    public UnityEvent OnExitComplete;

    protected bool transistionComplete = true;
    protected List<Transform> roomObjectList = new List<Transform>();

    // Use this for initialization
    void Awake()
    {
        Transform[] transList = this.GetComponentsInChildren<Transform>();
        foreach (Transform transform in transList)
        {
            if (transform != this.transform)
            {
                roomObjectList.Add(transform);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
    }

    public virtual void Enter()
    {
        transistionComplete = false;
        OnEnter.Invoke();
    }
    public virtual void Exit()
    {
        transistionComplete = false;
        OnExit.Invoke();
    }

    public virtual bool TransistionComplete()
    {
        return transistionComplete;
    }
}