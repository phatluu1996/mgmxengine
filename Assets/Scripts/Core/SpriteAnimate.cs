using UnityEngine;

public class SpriteAnimate : IAnimation
{        
    private Animator m_Animator;    
    public Animator Animator { get => m_Animator; set => m_Animator = value; }
    private SpriteDataSet m_CurrentSpriteDataSet;
    public SpriteDataSet CurrentSpriteDataSet { get => m_CurrentSpriteDataSet; set => m_CurrentSpriteDataSet = value; }
    private SpriteData m_CurrentSpriteData;
    public SpriteData CurrentSpriteData { get => m_CurrentSpriteData; set => m_CurrentSpriteData = value; }
    private float m_NormalizeTime;     
    public float NormalizeTime { get => m_Animator.GetCurrentAnimatorStateInfo(0).normalizedTime; }

    public SpriteAnimate(Animator animator)
    {
        m_Animator = animator;
    }

    public void Animate(SpriteData spriteData, SpriteDataSet spriteDataSet, float normalizeTime)
    {         
        m_Animator.Play(spriteData.AnimationName, -1, normalizeTime);
        m_CurrentSpriteDataSet = spriteDataSet;
        m_CurrentSpriteData = spriteData;
    }

    public void Animate(SpriteData spriteData, SpriteDataSet spriteDataSet){      
        m_Animator.Play(spriteData.AnimationName);
        m_CurrentSpriteDataSet = spriteDataSet;
        m_CurrentSpriteData = spriteData;
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