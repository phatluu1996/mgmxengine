using System;
using Unity.VisualScripting;
using UnityEngine;

public class CameraEngine : MonoBehaviour
{
    [SerializeField]
    private Vector2 m_CameraSize = new Vector2(1600, 900);
    private Vector2 m_Position;
    public Vector2 CameraSize
    {
        get => m_CameraSize;
        set => m_CameraSize = value;
    }

    public Vector2 Position
    {
        get => transform.position;
        set
        {
            Vector3 pos = transform.position;
            pos.x = value.x;
            pos.y = value.y;
            transform.position = pos;
        }
    }
    
    [Header("Camera follow player")]
    public Transform m_Target;
    public Follow m_CameraFollow;

    public void Awake()
    {        
        m_CameraFollow = new Follow(m_Target, Vector2.up * 23, this, new Vector2(60f, 50f));
        Position = (Vector2)m_CameraFollow.Target.position + m_CameraFollow.TargetOffset;
    }

    public void LateUpdate()
    {
        m_CameraFollow?.Update();
    }
    
    public void OnDrawGizmos()
    {
        Utils.DrawBox(Position, m_CameraSize, Color.yellow);        
        m_CameraFollow?.DrawGizmos();
    }
}