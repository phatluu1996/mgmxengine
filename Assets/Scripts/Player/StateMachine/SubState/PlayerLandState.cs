using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGroundedState
{
    public PlayerLandState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        if(Input.AxisXHold != 0)
        {
            Player.Animator.SetBool("run_direct", true);
            StateMachine.To(States.Run);
            return;
        }else if(Input.Dash.Pressed){
            StateMachine.To(States.Dash);
            return;
        }else if(Input.Jump.Pressed){
            StateMachine.To(States.Jump);
            return;
        }
        VelocicyX = 0;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
        StateMachine.To(States.Idle);
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
            Player.Animator.SetBool("run_direct", true);
            StateMachine.To(States.Run);
            return;
        }else if(Input.Dash.Pressed){
            StateMachine.To(States.Dash);
            return;
        }else if(Input.Jump.Pressed){
            StateMachine.To(States.Jump);
            return;
        }
    }
}
