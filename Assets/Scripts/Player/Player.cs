using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IDamageable
{
    #region Singleton
    private static Player m_Instance;
    public static Player Instance { get => m_Instance; set => m_Instance = value; }
    #endregion

    #region Start Beam down
    [SerializeField]
    private bool m_StartBeamDown;
    public bool StartBeamDown { get => m_StartBeamDown; set => m_StartBeamDown = value; }
    #endregion
    
    #region Component
    [SerializeField]
    private SpriteDataSet m_CurrentSpriteDataSet;
    [SerializeField]
    private SpriteAnimate m_SpriteAnimate;
    [SerializeField]
    private PlayerStateMachine m_StateMachine;
    [SerializeField]
    private BoxCollider2D m_HitBox;
    [SerializeField]
    private BoxCollider2D m_HurtBox;
    [SerializeField]
    private PlayerStateManager m_StateManager;
    [SerializeField]
    private SpriteSetsManager m_SpriteSetsManager;
    [SerializeField]
    private InputHandler m_InputHandler;
    [SerializeField]
    private PlayerPhysicsData m_PhysicsData;
    [SerializeField]
    private PlayerController m_Controller;
    public SpriteDataSet CurrentSpriteDataSet { get => m_CurrentSpriteDataSet; set => m_CurrentSpriteDataSet = value; }
    public SpriteAnimate SpriteAnimate { get => m_SpriteAnimate; set => m_SpriteAnimate = value; }
    public PlayerStateMachine StateMachine { get => m_StateMachine; set => m_StateMachine = value; }
    public BoxCollider2D HitBox { get => m_HitBox; set => m_HitBox = value; }
    public BoxCollider2D HurtBox { get => m_HurtBox; set => m_HurtBox = value; }
    public PlayerStateManager StateManager { get => m_StateManager; set => m_StateManager = value; }
    public SpriteSetsManager SpriteSetsManager { get => m_SpriteSetsManager; set => m_SpriteSetsManager = value; }
    public InputHandler InputHandler { get => m_InputHandler; set => m_InputHandler = value; }
    public PlayerPhysicsData PhysicsData { get => m_PhysicsData; set => m_PhysicsData = value; }
    public PlayerController Controller { get => m_Controller; set => m_Controller = value; }
    #endregion

    #region Variables
    [SerializeField]
    private bool m_IsAttack;
    private int m_AttackIndex;
    public bool IsAttack { get => m_IsAttack; set => m_IsAttack = value; }
    public int AttackIndex { get => m_AttackIndex; set => m_AttackIndex = value; }
    #endregion

    #region Dash
    [SerializeField]
    private float m_DashTime;
    public float DashTime { get => m_DashTime; set => m_DashTime = value; }
    [SerializeField]
    private float m_AirDashTime;
    public float AirDashTime { get => m_AirDashTime; set => m_AirDashTime = value; }
    private bool m_DashJump;
    public bool DashJump { get => m_DashJump; set => m_DashJump = value; }
    private bool m_AirDash;
    public bool AirDash { get => m_AirDash; set => m_AirDash = value; }
    #endregion

    #region Wall
    [Range(0, 15)]
    public float m_WallJumpFrames = 5;
    #endregion 

    #region Ladder
    [SerializeField]
    private LayerMask m_LadderMask;
    public LayerMask LadderMask { get => m_LadderMask; set => m_LadderMask = value; }
    #endregion

    public void Damage(int damage, RaycastHit2D hit)
    {

    }

    public void Destroy()
    {

    }

    public override void Awake()
    {
        base.Awake();
        m_Instance = this;
        Application.targetFrameRate = 60;        
        m_SpriteAnimate = new SpriteAnimate(Animator);
        m_InputHandler = new InputHandler();
        m_StateMachine = new PlayerStateMachine();
        m_StateManager = new PlayerStateManager(m_StateMachine, this, m_SpriteSetsManager);
        m_StateMachine.Init(StartBeamDown ? m_StateManager.BeamDown : m_StateManager.Idle);
        Controller.collisions.below = true;
    }

    public override void Start()
    {
        base.Start();
    }

    public override void Update()
    {
        base.Update();

        m_StateMachine.CurrentState.OnUpdate();

        Controller.Move(Velocity * Application.targetFrameRate * Time.deltaTime);
    }

    public override void FixedUpdate()
    {
        base.FixedUpdate();
    }

    public override void OnBecameInvisible()
    {
        base.OnBecameInvisible();
    }

    public override void OnBecameVisible()
    {
        base.OnBecameVisible();
    }

    public override void OnDisable()
    {
        base.OnDisable();
    }

    public override void OnEnable()
    {
        base.OnEnable();
    }

    public override void OnFinish(int index)
    {
        base.OnFinish(index);
        m_StateMachine.CurrentState.OnFinish(index);
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
        m_StateMachine.CurrentState.OnTrigger(index);
    }

    public virtual void AnimationTransit(SpriteDataSet spriteDataSet, float normalizeTime)
    {
        CurrentSpriteDataSet = spriteDataSet;
    }
}