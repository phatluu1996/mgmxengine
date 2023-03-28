using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerArialState
{
    public PlayerWallJumpState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        VelocicyY = Physics.JumpSpeed;
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
        if(VelocicyY <= 0 || Collisions.above || !Input.Jump.Hold){
            if(!Input.Jump.Hold){
                VelocicyY = 0;
            }
            StateMachine.To(States.Fall);
            return;
        }else if(Input.Up.Hold && States.ClimbLadder.m_Ladder != null){
            StateMachine.To(States.ClimbLadder);
            return;
        }else if (Input.Dash.Pressed && !Player.AirDash && !Player.DashJump)
        {
            Player.AirDash = true;
            StateMachine.To(States.Dash);
            return;
        }
    }
}
