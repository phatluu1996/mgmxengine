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
        VelocicyX = (Player.DashJump ? Physics.DashSpeed : Physics.RunSpeed) * Input.AxisXHold;
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
    }
}
