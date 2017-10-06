using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum STATUS_EFFECT
{
    STATUS_ROLLCAM,

    STATUS_END
}

public class Status : MonoBehaviour
{
    private Player entity;
    
    List<StatusEffect> effectList = new List<StatusEffect>();
    
    private void Awake()
    {
        entity = this.GetComponent<Player>();
    }
    void Start()
    {

    }

    public void AddColorFadeEffect()
    {
        DrugEffect_ColorFade effect = new DrugEffect_ColorFade();
        effect.Init(entity);
        effectList.Add(effect);
    }

    public void AddGrainEffect()
    {
        DrugEffect_RollCamera effect = new DrugEffect_RollCamera();
        effect.Init(entity);
        effectList.Add(effect);
    }

    public void AddEffect(STATUS_EFFECT effectType)
    {

    }

    public void RemoveEffect(STATUS_EFFECT effectType)
    {

    }

    // Update is called once per frame
    void Update()
    {
        for(int i = 0; i < effectList.Count; ++i)
        {
            if (effectList[i].isActive)
                effectList[i].StatusEffectUpdate(entity);
            else
            {
                effectList[i].Exit(entity);
                effectList.RemoveAt(i);
            }
        }
    }
}