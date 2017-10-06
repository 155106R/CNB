using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class DrugEffect_RollCamera : StatusEffect
{
    public PostProcessingProfile testy;

    public override void Init(Player entity)
    {
        base.Init(entity);

        PostProcessingProfile testy = GameObject.Find("Camera (eye)").GetComponent<PostProcessingBehaviour>().profile;
        GrainModel.Settings lmao = new GrainModel.Settings();
        lmao = testy.grain.settings;
        lmao.intensity = 1.0f;
        testy.grain.settings = lmao;
        PPPController.Instance.Settings_Grain(lmao.intensity, lmao.luminanceContribution, lmao.size, lmao.colored);
    }
    public override void Exit(Player entity)
    {
        base.Exit(entity);

        PostProcessingProfile testy = GameObject.Find("Camera (eye)").GetComponent<PostProcessingBehaviour>().profile;
        GrainModel.Settings lmao = new GrainModel.Settings();
        lmao = testy.grain.settings;
        lmao.intensity = 0.0f;
        testy.grain.settings = lmao;
    }

    // Update is called once per frame
    public override void StatusEffectUpdate(Player entity)
    {
        base.StatusEffectUpdate(entity);
        //if (Input.GetKeyDown(KeyCode.E))
        //{
        //    GetComponent<Camera>().rotation = Quaternion.identity;
        //    rollCam = !rollCam;
        //}
        //if (Input.GetKeyDown(KeyCode.W))
        //{
        //    rollSpeed += 5.0f;
        //}
        //if (Input.GetKeyDown(KeyCode.Q))
        //{
        //    rollSpeed -= 5.0f;
        //}
        //if (Input.GetKeyDown(KeyCode.S))
        //{
        //    rollLimit += 2.0f;
        //}
        //if (Input.GetKeyDown(KeyCode.A))
        //{
        //    rollLimit -= 2.0f;
        //}

        //if (rollCam && GetComponent<Camera>())
        //{
        //    if (rollDir * GetComponent<Camera>().rotation.z * 180.0f >= rollLimit * 2)
        //    {
        //        rollDir = -rollDir;
        //    }
        //    GetComponent<Camera>().Rotate(Vector3.forward * rollDir * rollSpeed * Time.deltaTime);
        //}
    }
}
