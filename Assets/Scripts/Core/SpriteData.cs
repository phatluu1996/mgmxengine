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
}