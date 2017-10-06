using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch2 : MonoBehaviour {

    public List<Light> lightSourceList;
    
    private List<Light> defaultLightInfoList = new List<Light>();

	// Use this for initializatsation
	void Awake ()
    {
        foreach (Light light in lightSourceList)
        {
            Light defaultLight = new Light();
            defaultLight = Light.Instantiate(light);
            defaultLight.enabled = false;
            defaultLightInfoList.Add(defaultLight);
        }
	}
	
	// Update is called once per frame
	void Update ()  
    {
	}
}