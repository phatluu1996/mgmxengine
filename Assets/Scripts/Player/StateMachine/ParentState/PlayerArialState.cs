using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerArialState : PlayerState
{
    public PlayerArialState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }
   
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        Input.Check();
        VelocicyY =  Mathf.Clamp(VelocicyY - Physics.Gravity * Application.targetFrameRate * Time.deltaTime, -5.5f, 5.5f);
        if(Input.AxisXHold != 0){
            Player.DirX = Input.AxisXHold;
        }
    }
}
