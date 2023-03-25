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
        if(IsAttack){
            SpriteAnimate.Animate(spriteDataSet.AttackSpriteDatas[AttackIndex], normalizeTime);
        }else{
            SpriteAnimate.Animate(spriteDataSet.SpriteData, normalizeTime);
        }  
    }
}
