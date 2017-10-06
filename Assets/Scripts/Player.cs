using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonTemplate<Player> {

    protected Player() { } // guarantee this will be always a singleton only - can't use the constructor!

    public GameObject head;
    public GameObject leftArm;
    public GameObject rightArm;
    public Status statusEffectManager;

    // Use this for initialization
    private void Awake()
    {
        statusEffectManager = this.GetComponent<Status>();
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
