using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : Entity, IDamageable
{
    [SerializeField]
    private bool m_StartBeamDown;
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



    public bool StartBeamDown { get => m_StartBeamDown; set => m_StartBeamDown = value; }
    public SpriteData CurrentSpriteData { get => m_CurrentSpriteData; set => m_CurrentSpriteData = value; }
    public SpriteAnimate SpriteAnimate { get => m_SpriteAnimate; set => m_SpriteAnimate = value; }
    public PlayerStateMachine StateMachine { get => m_StateMachine; set => m_StateMachine = value; }
    public BoxCollider2D HitBox { get => m_HitBox; set => m_HitBox = value; }
    public BoxCollider2D HurtBox { get => m_HurtBox; set => m_HurtBox = value; }
    public PlayerStateManager StateManager { get => m_StateManager; set => m_StateManager = value; }
    public SpriteSetsManager SpriteSetsManager { get => m_SpriteSetsManager; set => m_SpriteSetsManager = value; }
    public InputHandler InputHandler { get => m_InputHandler; set => m_InputHandler = value; }
    public PlayerPhysicsData PhysicsData { get => m_PhysicsData; set => m_PhysicsData = value; }

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

        transform.Translate(Velocity * Application.targetFrameRate * Time.deltaTime);
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
    }

    public override void OnTrigger(int index)
    {
        base.OnTrigger(index);
    }
}
