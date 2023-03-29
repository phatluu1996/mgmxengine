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
        if(IsAttack)
        {
            SpriteData sprite = spriteDataSet.AttackSpriteDatas[0];
            SpriteAnimate.Animate(sprite, spriteDataSet, sprite.RealTransitTime(SpriteAnimate));
        }else{
            SpriteAnimate.Animate(spriteDataSet.SpriteData, spriteDataSet);
        }  
    }

    public override void AttackHandling(PlayerState playerState)
    {        
        
        if(InputHandler.Attack.Pressed && !IsAttack && playerState.SpriteDataSet.AttackSpriteDatas.Length != 0){
            IsAttack = true;
            AttackTimer = 0;
            SpriteData sprite = playerState.SpriteDataSet.AttackSpriteDatas[0];
            SpriteAnimate.Animate(sprite, playerState.SpriteDataSet, sprite.RealStartTime(SpriteAnimate));
        }

        if(IsAttack){
            AttackTimer += Time.deltaTime;
            if(AttackTimer >= 0.15f && InputHandler.Attack.Pressed){
                AttackTimer = 0;
                if(SpriteAnimate.CurrentSpriteData.RepeatTime >= 0){
                     SpriteData sprite = playerState.SpriteDataSet.AttackSpriteDatas[0];
                     SpriteAnimate.Animate(sprite, playerState.SpriteDataSet, sprite.RepeatTime);
                }    
            }

            float limitTime = 0.462f;
            
            if(AttackTimer >= limitTime){
                IsAttack = false;
                AttackTimer = 0;
                SpriteData normalSprite = playerState.SpriteDataSet.SpriteData;
                SpriteAnimate.Animate(normalSprite, playerState.SpriteDataSet, SpriteAnimate.CurrentSpriteData.RealContinueTime(SpriteAnimate));
            }            
        }
    }
}
