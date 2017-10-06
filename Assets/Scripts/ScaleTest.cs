using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScaleTest : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        foreach (Transform transform in this.GetComponentInChildren<Transform>())
        {
            Vector3 direction = new Vector3(0, 0, 1);
            direction.y = 0;
            direction.Normalize();
            this.transform.position += direction * 1.0f * Time.deltaTime;
            this.transform.localScale += direction * 3.0f * Time.deltaTime;
        }
    }
}