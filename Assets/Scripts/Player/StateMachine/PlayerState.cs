using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : AbstractState
{
    private Player m_Player;
    private PlayerStateMachine m_StateMachine;
    private SpriteDataSet m_SpriteDataSet;

    public PlayerStateMachine StateMachine { get => m_StateMachine; set => m_StateMachine = value; }
    public Player Player { get => m_Player; set => m_Player = value; }
    public SpriteDataSet SpriteData { get => m_SpriteDataSet; set => m_SpriteDataSet = value; }
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
        Timer = 0;
        AnimationFinish = false;
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        OnEnter();
        if (!stopAttack)
        {
            Player.AnimationTransit(SpriteData, normalizeTime);
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

    }

    public override void OnFinish(int index)
    {
        AnimationFinish = true;
    }

    public override void OnTrigger(int index)
    {

    }
}
