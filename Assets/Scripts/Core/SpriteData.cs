using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteData", menuName = "mgmxengine/SpriteData", order = 0)]
[Serializable]
public class SpriteData : ScriptableObject {
    [SerializeField]
    private AnimationClip m_AnimationClip;
    [SerializeField]
    private bool m_UseAnimationLength;
    [SerializeField]
    private int m_damage;
    public AnimationClip AnimationClip { get => m_AnimationClip; set => m_AnimationClip = value; }
    public float Length => m_AnimationClip.length;
    public string AnimationName => m_AnimationClip.name;
    public bool UseAnimationLength { get => m_UseAnimationLength; set => m_UseAnimationLength = value; }
    public int Damage { get => m_damage; set => m_damage = value; }
    [SerializeField]
    private float m_StartTime;    
    public float StartTime {get => m_StartTime; set => m_StartTime = value; }
    public float RealStartTime(SpriteAnimate spriteAnimate) => m_StartTime < 0 ? spriteAnimate.NormalizeTime : m_StartTime;
    [SerializeField]
    private float m_TransitTime;    
    public float TransitTime {get => m_TransitTime; set => m_TransitTime = value; }
    [SerializeField]
    private float m_RepeatTime;
    public float RepeatTime {get => m_RepeatTime; set => m_RepeatTime = value; }    
    public float RealTransitTime(SpriteAnimate spriteAnimate) => m_TransitTime < 0 ? spriteAnimate.NormalizeTime : m_TransitTime;
    [SerializeField]
    private float m_ContinueTime;
    public float ContinueTime {get => m_ContinueTime; set => m_ContinueTime = value; }    
    public float RealContinueTime(SpriteAnimate spriteAnimate) => m_ContinueTime < 0 ? spriteAnimate.NormalizeTime : m_ContinueTime;
    
}