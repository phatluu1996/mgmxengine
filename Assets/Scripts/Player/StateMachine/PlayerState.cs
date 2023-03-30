using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : AbstractState
{
    public int m_AnimationIndex;
    private Player m_Player;
    private PlayerStateMachine m_StateMachine;
    private SpriteDataSet m_SpriteDataSet;
    public PlayerStateMachine StateMachine { get => m_StateMachine; set => m_StateMachine = value; }
    public Player Player { get => m_Player; set => m_Player = value; }
    public SpriteDataSet SpriteDataSet { get => m_SpriteDataSet; set => m_SpriteDataSet = value; }
    public InputHandler Input { get => Player.InputHandler; }
    public PlayerState PrevState { get => Player.StateMachine.PrevState; }
    public PlayerStateManager States { get => Player.StateManager; }
    public Animator Animator { get => Player.Animator; }
    public Vector2 Velocicy { get => Player.Velocity; set => Player.Velocity = value; }
    public float VelocicyX { get => Player.VelocityX; set => Player.VelocityX = value; }
    public float VelocicyY { get => Player.VelocityY; set => Player.VelocityY = value; }
    public PlayerPhysicsData Physics => Player.PhysicsData;
    public PlayerController.CollisionInfo Collisions => Player.Controller.collisions;
    public PlayerState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base()
    {
        m_StateMachine = stateMachine;
        m_Player = player;
        m_SpriteDataSet = spriteDataSet;
    }

    public override void OnEnter()
    {
        m_AnimationIndex = 0;
        Timer = 0;
        AnimationFinish = false;
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        OnEnter();
        if (!stopAttack)
        {
            Player.AnimationTransit(SpriteDataSet, normalizeTime);
        }
        else
        {
            
        }
    }

    public override void OnExit()
    {

    }



    public override void OnUpdate()
    {
        Player.AttackHandling(this);
    }

    public override void OnFinish(int index)
    {
        AnimationFinish = true;
    }

    public override void OnTrigger(int index)
    {
        
    }
}
