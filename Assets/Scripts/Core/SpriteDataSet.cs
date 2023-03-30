using System;
using UnityEngine;

[CreateAssetMenu(fileName = "SpriteDataSet", menuName = "mgmxengine/SpriteDataSet", order = 1)]
[Serializable]
public class SpriteDataSet : ScriptableObject {
    [SerializeField]
    private SpriteData[] m_SpriteDatas;
    [SerializeField]
    private SpriteData[] m_AttackSpriteData;
    [SerializeField]
    private SpriteData[] m_ChargeAttackSpriteData;
    [SerializeField]
    private SpriteData[] m_SpecialAttackSpriteDatas;
    public SpriteData[] SpriteDatas { get => m_SpriteDatas; set => m_SpriteDatas = value; }
    public SpriteData[] AttackSpriteDatas { get => m_AttackSpriteData; set => m_AttackSpriteData = value; }
    public SpriteData[] AttackChargeSpriteDatas { get => m_ChargeAttackSpriteData; set => m_ChargeAttackSpriteData = value; }
    public SpriteData[] SpecialAttackSpriteDatas { get => m_SpecialAttackSpriteDatas; set => m_SpecialAttackSpriteDatas = value; }
}