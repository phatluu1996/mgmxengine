using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerWallState
{
    public PlayerWallSlideState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        Player.DashJump = false;
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
        VelocicyY = -Physics.WallSlideSpeed;

        if(Collisions.below){
            StateMachine.To(States.Idle);
            return;
        }else if(Input.AxisXHold != m_WallDirection){
            States.Fall.m_LeaveWall = true;            
            StateMachine.To(States.Fall);
            return;
        }else if(Input.Jump.Pressed){
            Player.DashJump = Input.Dash.Hold;     
            States.WallJump.m_Jump = true;   
            States.WallJump.m_LeaveWall = true;    
            StateMachine.To(States.WallJump);
            return;
        }
    }
}
