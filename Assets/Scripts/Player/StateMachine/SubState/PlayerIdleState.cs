using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerIdleState : PlayerGroundedState
{
    public PlayerIdleState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
        VelocicyX = 0;
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
        if(Input.AxisXHold != 0)
        {
            StateMachine.To(States.Run);
            return;
        }else if(Input.Dash.Pressed){
            StateMachine.To(States.Dash);
            return;
        }else if(Input.Jump.Pressed){
            Player.DashJump = Input.Dash.Hold;
            StateMachine.To(States.Jump);
            return;
        }else if(!Collisions.below){
            StateMachine.To(States.Fall);
            return;
        }else if(Input.Down.Hold){
            if(m_CanClimbDownLadder){
                StateMachine.To(States.ClimbLadderDown);
            }else{
                StateMachine.To(States.Crouch);
            }            
            return;
        }else if(Input.Up.Hold && States.ClimbLadder.m_Ladder != null && !m_CanClimbDownLadder){
            StateMachine.To(States.ClimbLadder);
            return;
        }
    }
}