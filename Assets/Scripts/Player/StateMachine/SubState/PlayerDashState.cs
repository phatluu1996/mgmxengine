using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashState : PlayerGroundedState
{
    public float m_SmoothX;
    public bool m_StartDash;
    public float m_DashDirection;
    public PlayerDashState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        m_DashDirection = Player.DirX;
    }

    public override void OnExit()
    {
        base.OnExit();       
        m_SmoothX = 0; 
        m_StartDash = false;
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
        StateMachine.To(States.Idle);
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
        m_StartDash = true;
        if(index == -1){
            m_AnimationIndex = 1;
            Player.AnimationConnect(this, this.SpriteDataSet);
        } 
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        
        Timer += Time.deltaTime;
        if (Player.AirDash)
        {
            VelocicyY = 0;
            if (Collisions.below)
            {
                Player.AirDash = false;
                VelocicyY = -Physics.JumpSpeed;
            }

            if (Timer >= Player.AirDashTime)
            {
                if (Collisions.below)
                {
                    StateMachine.To(States.Idle);
                    return;
                }
                else
                {
                    StateMachine.To(States.Fall);
                    return;
                }
            }
        }
        if(!Player.AirDash && ((!Input.Dash.Hold && Input.AxisXHold == 0) || Timer >= Player.DashTime)){
            if (Input.AxisXHold != 0)
            {                
                StateMachine.To(States.Run);
                return;
            }

            if(m_AnimationIndex == 1){
                m_AnimationIndex = 2;
                Player.AnimationConnect(this, this.SpriteDataSet);
                m_SmoothX = 0;
                m_StartDash = false;      
                  
                if(Timer < Player.DashTime){
                    VelocicyX = m_DashDirection * 0.1f;
                }else{
                    VelocicyX/=3;
                }
            }

            VelocicyX = Mathf.SmoothDamp(VelocicyX, 0,ref m_SmoothX, 0.4f);
        }else{
            if(Input.Dash.Pressed && m_AnimationIndex == 2){
                m_StartDash = false;
                m_AnimationIndex = 0;
                Debug.Log("Pre dash !");
                Player.AnimationConnect(this, this.SpriteDataSet);
                m_SmoothX = 0;
                Timer = 0;
            }
            float speed = Player.AirDash ? Physics.AirDashSpeed : Physics.DashSpeed;
            if(!m_StartDash){
                speed = Physics.DashPreSpeed;
            }
            VelocicyX = speed * m_DashDirection;
        }

        if(Player.DirX != m_DashDirection){
            if (Player.AirDash)
            {
                StateMachine.To(States.Fall);
                return;
            }
            else
            {
                StateMachine.To(States.Run);
                return;
            }
        }else if(Input.Jump.Pressed && !Player.AirDash){
            Player.DashJump = true;
            StateMachine.To(States.Jump);
            return;
        }else if((!Player.AirDash && !Collisions.below) || (Player.AirDash && !Input.Dash.Hold) || Collisions.right || Collisions.left){
            StateMachine.To(States.Fall);
            return;
        }
    }
}