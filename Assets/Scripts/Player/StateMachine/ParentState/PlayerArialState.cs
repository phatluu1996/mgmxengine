using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerArialState : PlayerState
{
    private float m_SmoothX;
    public bool m_LeaveWall = false;
    public bool m_Jump = false;
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
        m_Jump = false;
        m_LeaveWall = false;
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
        States.ClimbLadder.CheckLadder();
        Input.Check();
        base.OnUpdate();
        if (m_LeaveWall)
        {
            Input.AxisXUnlocked = false;
            if (m_Jump)
            {
                VelocicyX = -(Player.DashJump ? Physics.DashSpeed : Physics.RunSpeed) * Player.DirX;  
                Timer += Time.deltaTime;  
                float leaveTime = Player.m_WallJumpFrames / Application.targetFrameRate;
                if (Timer >= leaveTime)
                {
                    Timer = 0;
                    m_LeaveWall = false;
                    m_Jump = false;
                }           
            }
            else
            {
                VelocicyX = Player.DirX * 1;
                Timer += Time.deltaTime;
                float leaveTime = 5f / Application.targetFrameRate;
                if (Timer >= leaveTime)
                {
                    Timer = 0;
                    m_LeaveWall = false;
                }
            }

        }
        else
        {
            Input.AxisXUnlocked = true;
            if (Input.AxisXHold != 0)
            {
                Player.DirX = Input.AxisXHold;
            }

            VelocicyX = (Player.DashJump ? Physics.DashSpeed : Physics.RunSpeed) * Input.AxisXHold;
        }
        VelocicyY = Mathf.Clamp(VelocicyY - Physics.Gravity * Application.targetFrameRate * Time.deltaTime, -5.5f, 5.5f);
    }
}
