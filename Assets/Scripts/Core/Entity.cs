using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Entity : MonoBehaviour
{
    [SerializeField]
    private SpriteRenderer m_SpriteRenderer;
    [SerializeField]
    private Animator m_Animator; 
    [SerializeField]
    private Vector2 m_Velocity;
    public SpriteRenderer SR { get => m_SpriteRenderer; set => m_SpriteRenderer = value; }
    public Animator Animator { get => m_Animator; set => m_Animator = value; }
    public Vector2 Position { get => transform.position; set => transform.position = value; }
    public Vector2 Velocity { get => m_Velocity; set => m_Velocity = value; }
    public float VelocityX { get => m_Velocity.x; set => m_Velocity.x = value; }
    public float VelocityY { get => m_Velocity.y; set => m_Velocity.y = value; }
    public float ScaleX
    {
        get => transform.localScale.x;
        set
        {
            Vector3 scale = transform.localScale;
            scale.x = value;
            transform.localScale = scale;
        }
    }
    public float DirX
    {
        get => Mathf.Sign(transform.localScale.x);
        set
        {
            Vector3 scale = transform.localScale;
            scale.x = Mathf.Sign(value);
            transform.localScale = scale;
        }
    }

    public float x
    {
        get => transform.position.x;
        set{
            Vector2 pos = transform.position;
            pos.x = value;
            transform.position = pos;
        }
    }

    public float y
    {
        get => transform.position.x;
        set{
            Vector2 pos = transform.position;
            pos.y = value;
            transform.position = pos;
        }
    }

    

    public virtual void Awake()
    {
        
    }

    public virtual void Start()
    {

    }

    public virtual void Update()
    {

    }

    public virtual void FixedUpdate()
    {
        
    }

    public virtual void OnEnable()
    {

    }

    public virtual void OnDisable()
    {

    }

    public virtual void OnBecameInvisible()
    {

    }

    public virtual void OnBecameVisible()
    {

    }

    public virtual void OnFinish(int index)
    {

    }

    public virtual void OnTrigger(int index)
    {

    }
}
