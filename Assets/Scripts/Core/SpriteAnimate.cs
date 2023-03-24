using UnityEngine;

public class SpriteAnimate : IAnimation
{        
    private Animator m_Animator;    
    public Animator Animator { get => m_Animator; set => m_Animator = value; }
    private SpriteDataSet m_SpriteSet;
    public SpriteDataSet SpriteSet { get => m_SpriteSet; set => m_SpriteSet = value; }
    private SpriteData m_CurrentSpriteData;
    public SpriteData CurrentSpriteData { get => m_CurrentSpriteData; set => m_CurrentSpriteData = value; }
    private float m_NormalizeTime;     
    public float NormalizeTime { get => m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime; }

    public SpriteAnimate(Animator animator)
    {
        m_Animator = animator;
    }

    public void Animate(SpriteData spriteData, float normalizeTime)
    {
        m_CurrentSpriteData = spriteData;
        m_Animator.Play(spriteData.AnimationName, 0, normalizeTime);
    }

    public void Animate(SpriteData spriteData){

        m_CurrentSpriteData = spriteData;
        m_Animator.Play(spriteData.AnimationName, 0);
    }

    public float Length()
    {
        return m_CurrentSpriteData.Length;
    }

    public int Frame()
    {
        return (int)(m_NormalizeTime * m_CurrentSpriteData.Length);
    }
}