using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;

public class DrugEffect_ColorFade : StatusEffect
{
    public float fadeToEffectssTime;
    public float fadeFromEffectTime;

    public float fadeTimer;
    
    public override void Init(Player entity)
    {
        base.Init(entity);

        PostProcessingProfile testy = GameObject.Find("Camera (eye)").GetComponent<PostProcessingBehaviour>().profile;
        ColorGradingModel.Settings lmao = new ColorGradingModel.Settings();
        lmao = testy.colorGrading.settings;
        lmao.basic.saturation = 0.5f;
        testy.colorGrading.settings = lmao;
    }
    public override void Exit(Player entity)
    {
        base.Exit(entity);

        PostProcessingProfile testy = GameObject.Find("Camera (eye)").GetComponent<PostProcessingBehaviour>().profile;
        ColorGradingModel.Settings lmao = new ColorGradingModel.Settings();
        lmao = testy.colorGrading.settings;
        lmao.basic.saturation = 2.0f;
        testy.colorGrading.settings = lmao;
    }

    // Update is called once per frame
    public override void StatusEffectUpdate(Player entity)
    {
        base.StatusEffectUpdate(entity);
    }
}
