using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatusEffect {

    public bool isActive;
    public float lifetime;
    
    // Use this for initialization
    private void Awake()
    {
       
    }
    void Start () {
		
	}

    public virtual void Init(Player entity)
    {
        isActive = true;
        this.lifetime = 3.0f;
    }
    public virtual void Exit(Player entity)
    {
        
    }

    // Update is called once per frame
    public virtual void StatusEffectUpdate(Player entity)
    {
        if (!isActive)
            return;

        lifetime -= Time.deltaTime;
        if(lifetime <= 0.0f)
        {
            isActive = false;
        }
    }
}

/*
public class NewDrugEffect : MonoBehaviour {

    // Use this for initialization
    private void Awake()
    {
       
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void DrugEffectUpdate () {
		base.DrugEffectUpdate(player);
	}
}
*/
