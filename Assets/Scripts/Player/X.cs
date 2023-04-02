using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class X : Player
{
    public override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }

    public override void OnBecameVisible()
    {
        base.OnBecameVisible();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
    }

    public override void Awake()
    {
        base.Awake();
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void AnimationTransit(SpriteDataSet spriteDataSet, float normalizeTime)
    {
        base.AnimationTransit(spriteDataSet, normalizeTime);
        if (IsAttack)
        {
            SpriteData sprite = spriteDataSet.AttackSpriteDatas[0];
            SpriteAnimate.Animate(sprite, spriteDataSet, sprite.RealTransitTime(SpriteAnimate));
        }
        else
        {
            SpriteAnimate.Animate(spriteDataSet.SpriteDatas[0], spriteDataSet);
        }
    }

    public override void AnimationConnect(PlayerState playerState, SpriteDataSet spriteDataSet)
    {
        base.AnimationConnect(playerState, spriteDataSet);
        if (IsAttack)
        {
            SpriteData sprite = spriteDataSet.AttackSpriteDatas[playerState.m_AnimationIndex];
            if (sprite != null)
            {
                SpriteAnimate.Animate(sprite, spriteDataSet);
            }
        }
        else
        {
            SpriteData sprite = spriteDataSet.SpriteDatas[playerState.m_AnimationIndex];
            if (sprite != null)
            {
                SpriteAnimate.Animate(sprite, spriteDataSet);
            }
        }
    }

    public override void Charge(){
        if(InputHandler.Attack.Hold){
            ChargeTimer += Time.deltaTime * Application.targetFrameRate;
            if(ChargeTimer >= 30f && ChargeTimer < 80f){
                AttackIndex = 1;
                Charge_1.speed = 1;
                Charge_1.gameObject.SetActive(true);
            }else if(ChargeTimer >= 80f){
                AttackIndex = 2; 
                Charge_1.speed = 4f/3f;     
                Charge_2.gameObject.SetActive(true);                       
            }
        }
    }

    public override void AttackHandling(PlayerState playerState)
    {

        Charge();

        if (InputHandler.Attack.Released && !IsAttack && playerState.SpriteDataSet.AttackSpriteDatas.Length != 0)
        {
            IsAttack = true;
            AttackTimer = 0;
            ChargeTimer = 0;
            AttackIndex = 0;
            Charge_1.gameObject.SetActive(false);
            Charge_2.gameObject.SetActive(false);
            SpriteData sprite = playerState.SpriteDataSet.AttackSpriteDatas[playerState.m_AnimationIndex];
            SpriteAnimate.Animate(sprite, playerState.SpriteDataSet, sprite.RealStartTime(SpriteAnimate));
        }

        if (IsAttack)
        {
            AttackTimer += Time.deltaTime;
            if (AttackTimer >= 0.15f && InputHandler.Attack.Pressed)
            {
                AttackTimer = 0;
                ChargeTimer = 0;
                AttackIndex = 0;
                if (SpriteAnimate.CurrentSpriteData.RepeatTime >= 0)
                {
                    SpriteData sprite = playerState.SpriteDataSet.AttackSpriteDatas[playerState.m_AnimationIndex];
                    SpriteAnimate.Animate(sprite, playerState.SpriteDataSet, sprite.RepeatTime);
                }
            }

            float limitTime = 0.462f;

            if (AttackTimer >= limitTime)
            {
                IsAttack = false;
                AttackTimer = 0;
                ChargeTimer = 0;
                AttackIndex = 0;
                SpriteData normalSprite = playerState.SpriteDataSet.SpriteDatas[playerState.m_AnimationIndex];
                SpriteAnimate.Animate(normalSprite, playerState.SpriteDataSet, SpriteAnimate.CurrentSpriteData.RealContinueTime(SpriteAnimate));
            }
        }
    }
}
