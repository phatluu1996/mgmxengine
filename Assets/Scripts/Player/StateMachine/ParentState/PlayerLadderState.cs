using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLadderState : PlayerState
{
    public Transform m_Ladder;
    public PlayerLadderState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
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
        Player.x = m_Ladder.transform.position.x;
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
        Input.Check();        
    }

    public void CheckLadder(){
        RaycastHit2D ladderHit = Physics2D.BoxCast(Player.HitBox.bounds.center, Player.HitBox.bounds.size, 0, Vector2.zero, 0, Player.LadderMask);
        if(ladderHit && Player.x >= ladderHit.collider.bounds.min.x && Player.x <= ladderHit.collider.bounds.max.x){
            States.ClimbLadder.m_Ladder = States.ClimbLadderDown.m_Ladder = States.ClimbLadderUp.m_Ladder = ladderHit.transform;
        }else{
            States.ClimbLadder.m_Ladder = States.ClimbLadderDown.m_Ladder = States.ClimbLadderUp.m_Ladder = null;
        }
    }
}
