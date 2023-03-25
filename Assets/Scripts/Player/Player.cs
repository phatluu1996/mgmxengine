using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IDamageable
{
    
    [SerializeField]
    private bool m_StartBeamDown;
    public bool StartBeamDown { get => m_StartBeamDown; set => m_StartBeamDown = value; }
    #region Component
    [SerializeField]
    private SpriteData m_CurrentSpriteData;
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
    public SpriteData CurrentSpriteData { get => m_CurrentSpriteData; set => m_CurrentSpriteData = value; }
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
        Application.targetFrameRate = 60;
        m_SpriteAnimate = new SpriteAnimate(Animator);
        m_InputHandler = new InputHandler();
        m_StateMachine = new PlayerStateMachine();
        m_StateManager = new PlayerStateManager(m_StateMachine, this, m_SpriteSetsManager);
        m_StateMachine.Init(m_StateManager.Idle);
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

    public virtual void AnimationTransit(SpriteDataSet spriteDataSet, float normalizeTime){

    }
}
