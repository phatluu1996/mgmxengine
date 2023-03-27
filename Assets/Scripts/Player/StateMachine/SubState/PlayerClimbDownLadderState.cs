using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerClimbDownLadderState : PlayerLadderState
{
    public PlayerClimbDownLadderState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
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
        Player.x = m_Ladder.transform.position.x;
    }

    public override void OnExit()
    {
        base.OnExit();
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
        Player.y -= 18;
        StateMachine.To(States.ClimbLadder);
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
        Player.y -= 28;
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
    }
}
