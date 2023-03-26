using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStateManager {    
    [SerializeField]
    private PlayerState m_BeamDown;
    [SerializeField]
    private PlayerIdleState m_Idle;
    [SerializeField]
    private PlayerRunState m_Run;
    [SerializeField]
    private PlayerDashState m_Dash;
    [SerializeField]
    private PlayerJumpState m_Jump;
    [SerializeField]
    private PlayerFallState m_Fall;
    [SerializeField]
    private PlayerLandState m_Land;
    
    public PlayerState BeamDown { get => m_BeamDown; set => m_BeamDown = value; }
    public PlayerIdleState Idle { get => m_Idle; set => m_Idle = value; }
    public PlayerRunState Run { get => m_Run; set => m_Run = value; }
    public PlayerDashState Dash { get => m_Dash; set => m_Dash = value; }
    public PlayerJumpState Jump { get => m_Jump; set => m_Jump = value; }
    public PlayerFallState Fall { get => m_Fall; set => m_Fall = value; }
    public PlayerLandState Land { get => m_Land; set => m_Land = value; }

    public PlayerStateManager(PlayerStateMachine stateMachine, Player player, SpriteSetsManager spriteSetsManager)
    {
        m_Idle = new PlayerIdleState(stateMachine, player, spriteSetsManager.Idle);
        m_Run = new PlayerRunState(stateMachine, player, spriteSetsManager.Run);
        m_Dash = new PlayerDashState(stateMachine, player, spriteSetsManager.Dash);
        m_Jump = new PlayerJumpState(stateMachine, player, spriteSetsManager.Jump);
        m_Fall = new PlayerFallState(stateMachine, player, spriteSetsManager.Fall);
        m_Land = new PlayerLandState(stateMachine, player, spriteSetsManager.Land);
    }
}
