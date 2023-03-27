using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbUpLadderState : PlayerLadderState
{
    public PlayerClimbUpLadderState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        Player.y = m_Ladder.parent.position.y - 28f;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
        Player.x = m_Ladder.position.x;
        Player.Controller.collisions.below = true;
        VelocicyY = -5.25f;
        StateMachine.To(States.Idle);
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
        Player.y = m_Ladder.parent.position.y + 4 + 0.1f;
        
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
