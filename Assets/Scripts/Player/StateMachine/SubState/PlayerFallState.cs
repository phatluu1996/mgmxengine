using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFallState : PlayerArialState
{
    

    public PlayerFallState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);        
        VelocicyY = 0;
        if(m_LeaveWall){
            Player.DirX *= -1;
        }        
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
        if (Collisions.below)
        {
            if (Input.AxisXHold != 0)
            {
                Player.Animator.SetBool("run_direct", true);
                StateMachine.To(States.Run);
                return;
            }
            else
            {
                StateMachine.To(States.Land);
                return;
            }
        }
        else if ((Collisions.right || Collisions.left) && Input.AxisXHold != 0)
        {
            StateMachine.To(States.WallSlide);
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
