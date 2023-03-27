using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public bool m_CanJumpDownPlatform;
    public bool m_CanClimbDownLadder;
    public PlayerGroundedState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
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
        CheckGround();
        States.ClimbLadder.CheckLadder();
        Input.Check();
        VelocicyY = Mathf.Clamp(VelocicyY - Physics.Gravity * Application.targetFrameRate * Time.deltaTime, -5.5f, 5.5f);
        if (Input.AxisXHold != 0)
        {
            Player.DirX = Input.AxisXHold;
        }
    }

    public virtual void CheckGround()
    {
        m_CanJumpDownPlatform = false;
        m_CanClimbDownLadder = false;
        bool noCollideNonOneWay = true;
        PlayerController controller = Player.Controller;
        controller.UpdateRaycastOrigins();
        float rayLength = Mathf.Abs(VelocicyY) + AbstractController.skinWidth;
        for (int i = 0; i < controller.verticalRayCount; i++)
        {
            Vector2 rayOrigin = Player.DirX == -1 ? controller.raycastOrigins.bottomRight : controller.raycastOrigins.bottomLeft;
            rayOrigin += Vector2.right * Player.DirX * (controller.verticalRaySpacing * i + VelocicyX);
            RaycastHit2D hit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, controller.collisionMask);
            RaycastHit2D ladderHit = Physics2D.Raycast(rayOrigin, Vector2.down, rayLength, Player.LadderMask);
            Debug.DrawRay(rayOrigin, Vector2.down * rayLength, Color.yellow);

            if (hit)
            {                
                if (hit.collider.CompareTag("OneWay"))
                {
                    m_CanJumpDownPlatform = true;
                }
                else
                {
                    noCollideNonOneWay = false;
                }
            }

            if(ladderHit && Player.x <= ladderHit.collider.bounds.max.x && Player.x >= ladderHit.collider.bounds.min.x){
                m_CanClimbDownLadder = true;
                States.ClimbLadder.m_Ladder = States.ClimbLadderDown.m_Ladder = States.ClimbLadderUp.m_Ladder = ladderHit.transform;
            }
        }
        if (!noCollideNonOneWay)
        {
            m_CanJumpDownPlatform = false;
            m_CanClimbDownLadder = false;
            States.ClimbLadder.m_Ladder = States.ClimbLadderDown.m_Ladder = States.ClimbLadderUp.m_Ladder = null;
        }
    }
}


