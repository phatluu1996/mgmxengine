using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteDataSet", menuName = "mgmxengine/SpriteDataSet", order = 1)]
[Serializable]
public class SpriteDataSet : ScriptableObject {
    [SerializeField]
    private SpriteData m_SpriteData;
    [SerializeField]
    private SpriteData[] m_AttackSpriteData;
    [SerializeField]
    private SpriteData[] m_SpecialAttackSpriteDatas;
    public SpriteData SpriteData { get => m_SpriteData; set => m_SpriteData = value; }
    public SpriteData[] AttackSpriteDatas { get => m_AttackSpriteData; set => m_AttackSpriteData = value; }
    public SpriteData[] SpecialAttackSpriteDatas { get => m_SpecialAttackSpriteDatas; set => m_SpecialAttackSpriteDatas = value; }
}