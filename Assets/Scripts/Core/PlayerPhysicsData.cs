using UnityEngine;

[CreateAssetMenu(fileName = "PlayerPhysicsData", menuName = "mgmxengine/PlayerPhysicsData", order = 2)]
public class PlayerPhysicsData : ScriptableObject
{
    [SerializeField]
    private float m_Gravity;
    public float Gravity { get => m_Gravity; set => m_Gravity = value; }
    [SerializeField]
    private float m_RunSpeed;
    public float RunSpeed { get => m_RunSpeed; set => m_RunSpeed = value; }
    [SerializeField]
    private float m_DashSpeed;
    public float DashSpeed { get => m_DashSpeed; set => m_DashSpeed = value; }
    [SerializeField]
    private float m_DashPreSpeed;
    public float DashPreSpeed { get => m_DashPreSpeed; set => m_DashPreSpeed = value; }
    [SerializeField]
    private float m_JumpSpeed;
    public float JumpSpeed { get => m_JumpSpeed; set => m_JumpSpeed = value; }
    [SerializeField]
    private float m_WallSlideSpeed;
    public float WallSlideSpeed { get => m_WallSlideSpeed; set => m_WallSlideSpeed = value; }
    [SerializeField]
    private float m_ClimbLadderSpeed;
    public float ClimbLadderSpeed { get => m_ClimbLadderSpeed; set => m_ClimbLadderSpeed = value; }
    [SerializeField] 
    private float m_BeamDownSpeed;
    public float BeamDownSpeed { get => m_BeamDownSpeed; set => m_BeamDownSpeed = value; }
    [SerializeField] 
    private float m_BeamUpSpeed;
    public float BeamUpSpeed { get => m_BeamUpSpeed; set => m_BeamUpSpeed = value; }
}