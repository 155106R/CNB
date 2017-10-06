using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeenBallScript : QuestObject
{
    private bool set_to_move = false;

	// Update is called once per frame
	void Update () 
    {
        if(set_to_move)
            transform.localPosition = Vector3.Lerp(transform.localPosition, transform.localPosition + new Vector3(0, 0.1f, 0), 5f);
	}
    
    //Only called once
    public override void Activate()
    {
        if (HasBeenActivated())
            return;

        base.Activate();
        set_to_move = true;

        Debug.Log("Seenball Animation Started");
    }
}
