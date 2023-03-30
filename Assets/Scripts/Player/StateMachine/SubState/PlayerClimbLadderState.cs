using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbLadderState : PlayerLadderState
{
    public PlayerClimbLadderState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
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
        Animator.speed = 1;
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
        CheckLadder();    
        if (Input.AxisXHold != 0)
        {
            Player.DirX = Input.AxisXHold;
        }    
        VelocicyY = Input.AxisYHold * Physics.ClimbLadderSpeed * (!Player.IsAttack).GetHashCode();
        if(Input.AxisYPressed != 0){
            if (Input.AxisYHold < 0)
            {
                m_AnimationIndex = 0;
                Player.SpriteAnimate.Animate(SpriteDataSet.SpriteDatas[m_AnimationIndex], SpriteDataSet);
            }else{
                m_AnimationIndex = 1;
                Player.SpriteAnimate.Animate(SpriteDataSet.SpriteDatas[m_AnimationIndex], SpriteDataSet);
            }
        }

        if (Input.AxisYHold != 0 || Player.IsAttack)
        {            
            Animator.speed = 1;
        }
        else
        {
            Animator.speed = 0;
        }

        if (Collisions.below)
        {
            StateMachine.To(States.Idle);
            return;
        }
        else if (States.ClimbLadder.m_Ladder == null || Input.Jump.Pressed)
        {
            StateMachine.To(States.Fall);
            return;
        }
        else if (Player.HitBox.bounds.max.y > m_Ladder.parent.position.y + 2)
        {
            StateMachine.To(States.ClimbLadderUp);
            return;
        }
    }
}
