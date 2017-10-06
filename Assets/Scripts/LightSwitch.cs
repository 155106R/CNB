using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour {

    public Light[] lightSources;

    private List<float> original_light_values = new List<float>();
    bool is_collided = false;

    private SteamVR_TrackedObject trackedObj;
    private SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    private void Awake()
    {
        trackedObj = Player.Instance.leftArm.GetComponent<SteamVR_TrackedObject>();
    }

    // Use this for initialization
    void Start ()
    {
        for (int i = 0; i < lightSources.Length; ++i)
            original_light_values.Add(lightSources[i].intensity);
    }

    // Update is called once per frame
    void Update()
    {
        if (is_collided && Controller.GetHairTriggerDown())
                ToggleLights();
    }
    public void ToggleLights()
    {
        for (int i = 0; i < lightSources.Length; ++i)
        {
            if (lightSources[i].intensity <= 0) lightSources[i].intensity = original_light_values[i];
            else lightSources[i].intensity = 0.0f;
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            is_collided = true;
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.gameObject.tag == "Player")
            is_collided = false;
    }
}
