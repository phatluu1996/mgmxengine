using System;
using UnityEngine;

[Serializable]
public class Follow
{
    [SerializeField]
    private Transform m_Target;
    private Vector2 m_OldTargetPositionl;
    [SerializeField]
    private Vector2 m_TargetOffset = Vector2.zero;
    [SerializeField]
    private Vector2 m_SmoothFollowSpeed;
    [SerializeField]
    private CameraEngine m_CameraEngine;
    [SerializeField]
    private Vector2 m_DeadZone = Vector2.zero;
    public Transform Target
    {
        get => m_Target;
        set => m_Target = value;
    }

    public Vector2 TargetOffset
    {
        get => m_TargetOffset;
        set => m_TargetOffset = value;
    }

    public CameraEngine CameraEngine
    {
        get => m_CameraEngine;
        set => m_CameraEngine = value;
    }

    public Vector2 DeadZone
    {
        get => m_DeadZone;
        set => m_DeadZone = value;
    }
    
    // public float SmoothFollowSpeed
    // {
    //     get => m_SmoothFollowSpeed;
    //     set => m_SmoothFollowSpeed = value;
    // }

    public Follow(Transform target, CameraEngine cameraEngine, Vector2 deadZone)
    {
        m_Target = target;
        m_CameraEngine = cameraEngine;
        m_DeadZone = deadZone;
    }
    
    public void Update()
    {
        Vector2 cameraPosition = m_CameraEngine.Position;
        Vector2 targetPosition = (Vector2)m_Target.position + m_TargetOffset;
        if(m_DeadZone == Vector2.zero)
        {
            m_CameraEngine.Position = (Vector2)m_Target.position;
        }
        else
        {
            
            Rectangle deadzone = new Rectangle(cameraPosition, m_DeadZone);
            
            if(!deadzone.Contains((targetPosition)))
            {
                if(targetPosition.x > deadzone.TR.x || targetPosition.x < deadzone.TL.x)
                {
                    m_CameraEngine.Position += Vector2.right * (targetPosition - m_OldTargetPositionl);
                }

                if (targetPosition.y > deadzone.TL.y || targetPosition.y < deadzone.BL.y)
                {
                    m_CameraEngine.Position += Vector2.up * (targetPosition - m_OldTargetPositionl);
                }
            }
            else
            {
                
            }
            m_OldTargetPositionl = (Vector2)m_Target.position + m_TargetOffset;
        }

        
    }

    public void DrawGizmos()
    {
        if(m_DeadZone != Vector2.zero)
        {
            Utils.DrawBox(m_CameraEngine.Position, DeadZone, Color.red);
        }
    }
}