using System;
using UnityEngine;
[Serializable]
public class FollowModule : CameraEngineModule
{
    [SerializeField]
    private Transform m_Target;
    [SerializeField]
    private Vector2 m_OldTargetPosition { get; set; }
    [SerializeField]
    public Vector2 m_NewTargetPosition => (Vector2)m_Target.position + m_TargetOffset;
    [SerializeField]
    private Vector2 m_TargetOffset = Vector2.zero;
    [SerializeField]
    private Vector2 m_SmoothFollowSpeed;
    [SerializeField]
    private Vector2 m_DeadZone = Vector2.zero;
    [SerializeField]
    private Rectangle m_DeadzoneRectangle;

    [SerializeField]
    private bool m_StartOutOfDeadZone;
    [SerializeField]
    private float m_WaitTimeToApproachTarget;
    public Transform Target { get => m_Target; set => m_Target = value; }

    public Vector2 TargetOffset { get => m_TargetOffset; set => m_TargetOffset = value; }

    public Vector2 DeadZone { get => m_DeadZone; set => m_DeadZone = value; }
    public Rectangle DeadzoneRectangle { get => m_DeadzoneRectangle; set => m_DeadzoneRectangle = value; }

    public FollowModule(Transform target, Vector2 targetOffset, CameraEngine cameraEngine, Vector2 deadZone)
    {
        Setup(target, targetOffset, cameraEngine, deadZone);
    }

    public override void Excute()
    {
        base.Excute();
    }

    protected override void Update()
    {
        Vector2Int cameraPosition = new Vector2Int((int)m_CameraEngine.Position.x, (int)m_CameraEngine.Position.y);
        Vector2 targetPosition = (Vector2)m_NewTargetPosition;
        m_DeadzoneRectangle.Update(cameraPosition);
        if ((!m_DeadzoneRectangle.Contains((targetPosition)) && !m_DeadzoneRectangle.Contains((m_OldTargetPosition))) || m_StartOutOfDeadZone)
        {
            m_WaitTimeToApproachTarget += (Time.deltaTime * 20) / Vector2.Distance(cameraPosition, targetPosition);
            Vector2 newPosition = Vector2.Lerp(cameraPosition, targetPosition, m_WaitTimeToApproachTarget);
            if (m_WaitTimeToApproachTarget >= 1)
            {
                m_WaitTimeToApproachTarget = 0;
                m_StartOutOfDeadZone = false;
            }

            m_CameraEngine.transform.Translate((newPosition - m_CameraEngine.Position));
        }
        else
        {
            if (m_DeadZone == Vector2.zero)
            {
                m_CameraEngine.Position = (Vector2)m_Target.position;
            }
            else
            {
                if (!m_DeadzoneRectangle.Contains((targetPosition)))
                {
                    if (targetPosition.x > m_DeadzoneRectangle.TR.x || targetPosition.x < m_DeadzoneRectangle.TL.x)
                    {
                        m_CameraEngine.transform.Translate(Vector2.right * (targetPosition - m_OldTargetPosition));
                    }

                    if (targetPosition.y > m_DeadzoneRectangle.TL.y || targetPosition.y < m_DeadzoneRectangle.BL.y)
                    {
                        m_CameraEngine.transform.Translate(Vector2.up * (targetPosition - m_OldTargetPosition));
                    }
                }
            }
        }
        m_OldTargetPosition = (Vector2)targetPosition;
    }

    public void Setup(Transform target, Vector2 targetOffset, CameraEngine cameraEngine, Vector2 deadZone)
    {
        m_Target = target;
        m_TargetOffset = targetOffset;
        m_CameraEngine = cameraEngine;
        m_DeadZone = deadZone;
        m_DeadzoneRectangle = new Rectangle(cameraEngine.Position, m_DeadZone);
        m_OldTargetPosition = m_NewTargetPosition;
        m_WaitTimeToApproachTarget = 0;
        if (!m_DeadzoneRectangle.Contains((m_NewTargetPosition)))
        {
            m_StartOutOfDeadZone = true;
        }
    }

    public void SwitchTarget(Transform newTarget, Vector2 newOffset, Vector2 newDeadZone)
    {
        Setup(newTarget, newOffset, m_CameraEngine, newDeadZone);
    }

    public void JumpToTarget()
    {
        m_CameraEngine.Position = m_NewTargetPosition;
    }

    public override void DrawGizmos()
    {
        if (m_DeadZone != Vector2.zero)
        {
            Utils.DrawBox(m_CameraEngine.Position, DeadZone, Color.red);
        }
    }
}