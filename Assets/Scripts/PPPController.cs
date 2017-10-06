using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PostProcessing;
using UnityEngine.UI;

public enum PPP_EFFECT
{
    DEPTH_OF_FIELD,
    MOTION_BLUR,
    EYE_ADAPTATION,
    BLOOM,
    COLOR_GRADING,
    CHROMATIC_ABBERATION,
    GRAIN,
    VIGENTTE,

    NUM_EFFECTS
}

public class PPPController : SingletonTemplate<PPPController> {
    protected PPPController() { } // guarantee this will be always a singleton only - can't use the constructor!

    public PostProcessingProfile defaultPPP;
    public PostProcessingProfile ppp;
    public GameObject testy;

    PPP_EFFECT selected_effect = PPP_EFFECT.DEPTH_OF_FIELD;

    public Text current_effect;

	// Use this for initialization
	void Start ()
    {
        ppp = defaultPPP;
        testy.GetComponent<PostProcessingBehaviour>().profile = ppp;
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Depth of Field
             if (Input.GetKeyDown(KeyCode.F1)) selected_effect = PPP_EFFECT.DEPTH_OF_FIELD;
        else if (Input.GetKeyDown(KeyCode.F2)) selected_effect = PPP_EFFECT.MOTION_BLUR;
        else if (Input.GetKeyDown(KeyCode.F3)) selected_effect = PPP_EFFECT.EYE_ADAPTATION;
        else if (Input.GetKeyDown(KeyCode.F4)) selected_effect = PPP_EFFECT.BLOOM;
        else if (Input.GetKeyDown(KeyCode.F5)) selected_effect = PPP_EFFECT.COLOR_GRADING;
        else if (Input.GetKeyDown(KeyCode.F6)) selected_effect = PPP_EFFECT.CHROMATIC_ABBERATION;
        else if (Input.GetKeyDown(KeyCode.F7)) selected_effect = PPP_EFFECT.GRAIN;
        else if (Input.GetKeyDown(KeyCode.F8)) selected_effect = PPP_EFFECT.VIGENTTE;

        HandleSelectedEffect();

        UpdateUI();
        
    }

    void HandleSelectedEffect()
    {
        switch(selected_effect)
        {
            case PPP_EFFECT.DEPTH_OF_FIELD: HandleDepthOfField();                   break;
            case PPP_EFFECT.MOTION_BLUR:    HandleMotionBlur();                     break;
            case PPP_EFFECT.EYE_ADAPTATION: HandleEyeAdaptation();                  break;
            case PPP_EFFECT.BLOOM:          HandleBloom();                          break;
            case PPP_EFFECT.COLOR_GRADING:  Something();                            break;
            case PPP_EFFECT.CHROMATIC_ABBERATION: HandleChromaticAbberation();      break;
            case PPP_EFFECT.GRAIN: Something();                                     break;
            case PPP_EFFECT.VIGENTTE:       HandleVignette();                       break;
        }
    }

    void HandleDepthOfField()
    {
        var temp = ppp.depthOfField.settings;

        if (Input.GetKeyDown(KeyCode.Keypad0))
            ppp.depthOfField.enabled = !ppp.depthOfField.enabled;
        
        //Focus Distance
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            temp.focusDistance -= 2.5f;
        else if (Input.GetKeyDown(KeyCode.Keypad9))
            temp.focusDistance += 2.5f;

        //Focal Length
        else if (Input.GetKeyDown(KeyCode.Keypad4))
            temp.focalLength -= 10f;
        else if (Input.GetKeyDown(KeyCode.Keypad6))
            temp.focalLength += 10f;

        ppp.depthOfField.settings = temp;
    }

    void HandleMotionBlur()
    {
        var temp = ppp.motionBlur.settings;

        if (Input.GetKeyDown(KeyCode.Keypad0))
            ppp.motionBlur.enabled = !ppp.motionBlur.enabled;

        //Shutter Angle
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            temp.shutterAngle -= 10f;
        else if (Input.GetKeyDown(KeyCode.Keypad9))
            temp.shutterAngle += 10f;

        //Sample Count
        else if (Input.GetKeyDown(KeyCode.Keypad4))
            temp.sampleCount -= 1;
        else if (Input.GetKeyDown(KeyCode.Keypad6))
            temp.sampleCount += 1;

        //Flame Blending
        else if (Input.GetKeyDown(KeyCode.Keypad1))
            temp.frameBlending -= 0.1f;
        else if (Input.GetKeyDown(KeyCode.Keypad3))
            temp.frameBlending += 0.1f;

        ppp.motionBlur.settings = temp;
    }

    void HandleEyeAdaptation()
    {
        var temp = ppp.eyeAdaptation.settings;

        if (Input.GetKeyDown(KeyCode.Keypad0))
            ppp.eyeAdaptation.enabled = !ppp.eyeAdaptation.enabled;

        //Luminosity Range
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            temp.minLuminance -= 1f;
        else if (Input.GetKeyDown(KeyCode.Keypad9))
            temp.minLuminance += 1f;

        ppp.eyeAdaptation.settings = temp;
    }

    void HandleBloom()
    {
        var temp = ppp.bloom.settings;

        if (Input.GetKeyDown(KeyCode.Keypad0))
            ppp.bloom.enabled = !ppp.bloom.enabled;

        //Intensity
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            temp.bloom.intensity -= 0.25f;
        else if (Input.GetKeyDown(KeyCode.Keypad9))
            temp.bloom.intensity += 0.25f;

        ppp.bloom.settings = temp;
    }

    void HandleChromaticAbberation()
    {
        var temp = ppp.chromaticAberration.settings;

        if (Input.GetKeyDown(KeyCode.Keypad0))
            ppp.chromaticAberration.enabled = !ppp.chromaticAberration.enabled;

        ppp.chromaticAberration.settings = temp;
    }

    void HandleVignette()
    {
        var temp = ppp.vignette.settings;

        if (Input.GetKeyDown(KeyCode.Keypad0))
            ppp.vignette.enabled = !ppp.vignette.enabled;

        //Luminosity Range
        else if (Input.GetKeyDown(KeyCode.Keypad7))
            temp.intensity -= 0.25f;
        else if (Input.GetKeyDown(KeyCode.Keypad9))
            temp.intensity += 0.25f;

        ppp.vignette.settings = temp;
    }

    void Something()
    {

    }

    void UpdateUI()
    {
        if (current_effect == null)
            return;

        string asdf = "";
        switch (selected_effect)
        {
            case PPP_EFFECT.DEPTH_OF_FIELD: if (ppp.depthOfField.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.MOTION_BLUR: if (ppp.motionBlur.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.EYE_ADAPTATION: if (ppp.eyeAdaptation.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.BLOOM: if (ppp.bloom.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.COLOR_GRADING: if (ppp.colorGrading.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.CHROMATIC_ABBERATION: if (ppp.chromaticAberration.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.GRAIN: if (ppp.grain.enabled) asdf = "ON"; else asdf = "OFF"; break;
            case PPP_EFFECT.VIGENTTE: if (ppp.vignette.enabled) asdf = "ON"; else asdf = "OFF"; break;
        }

        current_effect.text = selected_effect.ToString() + " is " + asdf;
    }

    public void Settings_DepthOfField(float focus_distance, float aperture, bool use_camera_FOV, float focal_length, DepthOfFieldModel.KernelSize kernel_size)
    {
        DepthOfFieldModel.Settings settings = new DepthOfFieldModel.Settings();

        settings.focusDistance = focus_distance;
        settings.aperture = aperture;
        settings.useCameraFov = use_camera_FOV;
        settings.focalLength = focal_length;
        settings.kernelSize = kernel_size;

        ppp.depthOfField.settings = settings;
    }

    public void Settings_MotionBlur(float shuttle_angle, int sample_count, float frame_blending)
    {
        MotionBlurModel.Settings settings = new MotionBlurModel.Settings();

        settings.shutterAngle = shuttle_angle;
        settings.sampleCount = sample_count;
        settings.frameBlending = frame_blending;

        ppp.motionBlur.settings = settings;
    }

    public void Settings_EyeAdaptation(
        float luminosity_min, float luminosity_max, 
        float low_percent, float high_percent, 
        int exposure_min, int exposure_max, 
        bool dynamic_key, float key_value,
        EyeAdaptationModel.EyeAdaptationType adaptation_type, int adaptation_speed_up, int adaptation_speed_down)
    {
        EyeAdaptationModel.Settings settings = new EyeAdaptationModel.Settings();

        settings.minLuminance = luminosity_min;
        settings.maxLuminance = luminosity_max;
        settings.lowPercent = low_percent;
        settings.highPercent = high_percent;
        settings.logMin = exposure_min;
        settings.dynamicKeyValue = dynamic_key;
        settings.keyValue = key_value;
        settings.adaptationType = adaptation_type;
        settings.speedUp = adaptation_speed_up;
        settings.speedDown = adaptation_speed_down;

        ppp.eyeAdaptation.settings = settings;
    }

    public void Settings_Bloom(float bloom_intensity, float treshold, float soft_knee, float radius, bool anti_flicker, float dirt_intensity)
    {
        BloomModel.Settings settings = new BloomModel.Settings();

        settings.bloom.intensity = bloom_intensity;
        settings.bloom.threshold = treshold;
        settings.bloom.softKnee = soft_knee;
        settings.bloom.radius = radius;
        settings.bloom.antiFlicker = anti_flicker;
        settings.lensDirt.intensity = dirt_intensity;

        ppp.bloom.settings = settings;
    }

    public void Settings_Grain(float intensity, float luminace_contribution, float size, bool coloured)
    {
        GrainModel.Settings settings = new GrainModel.Settings();

        settings.intensity = intensity;
        settings.luminanceContribution = luminace_contribution;
        settings.size = size;
        settings.colored = coloured;

        ppp.grain.settings = settings;
    }

    public void Settings_Vignette(VignetteModel.Mode mode, Color color, Vector2 center, float intensity, float smoothness, float roundness, bool rounded)
    {
        VignetteModel.Settings settings = new VignetteModel.Settings();

        settings.mode = mode;
        settings.color = color;
        settings.center = center;
        settings.intensity = intensity;
        settings.smoothness = smoothness;
        settings.roundness = roundness;
        settings.rounded = rounded;

        ppp.vignette.settings = settings;
    }

    public void SetActivePostProcess(PPP_EFFECT effect, bool is_active)
    {
        switch (selected_effect)
        {
            case PPP_EFFECT.DEPTH_OF_FIELD: ppp.depthOfField.enabled = is_active; break;
            case PPP_EFFECT.MOTION_BLUR: ppp.motionBlur.enabled = is_active; break;
            case PPP_EFFECT.EYE_ADAPTATION: ppp.eyeAdaptation.enabled = is_active; break;
            case PPP_EFFECT.BLOOM: ppp.bloom.enabled = is_active; break;
            case PPP_EFFECT.COLOR_GRADING: ppp.colorGrading.enabled = is_active; break;
            case PPP_EFFECT.CHROMATIC_ABBERATION: ppp.chromaticAberration.enabled = is_active; break;
            case PPP_EFFECT.GRAIN: ppp.grain.enabled = is_active; break;
            case PPP_EFFECT.VIGENTTE: ppp.vignette.enabled = is_active; break;
        }
    }
}
