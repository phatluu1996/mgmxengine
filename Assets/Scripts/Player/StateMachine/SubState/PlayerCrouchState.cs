using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCrouchState : PlayerGroundedState
{
    public PlayerCrouchState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }
    
    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        VelocicyX = 0;
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
        if(Input.Dash.Pressed){
            StateMachine.To(States.Dash);
            return;
        }else if(Input.Jump.Pressed){
            if(m_CanJumpDownPlatform && Input.Down.Hold){
                Player.y -= 3f;                
                StateMachine.To(States.Fall);
            }else{
                Player.DashJump = Input.Dash.Hold;
                StateMachine.To(States.Jump);
            }            
            return;
        }else if(!Collisions.below){
            StateMachine.To(States.Fall);
            return;
        }else if(!Input.Down.Hold){
            StateMachine.To(States.Idle);
            return;
        }        
    }
}
