using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStateManager {    
    [SerializeField]
    private PlayerState m_BeamDown;
    [SerializeField]
    private PlayerState m_Idle;
    [SerializeField]
    private PlayerState m_Run;
    [SerializeField]
    private PlayerState m_Dash;
    [SerializeField]
    private PlayerState m_Jump;
    [SerializeField]
    private PlayerState m_Fall;
    [SerializeField]
    private PlayerState m_Land;
    public PlayerState BeamDown { get => m_BeamDown; set => m_BeamDown = value; }
    public PlayerState Idle { get => m_Idle; set => m_Idle = value; }
    public PlayerState Run { get => m_Run; set => m_Run = value; }
    public PlayerState Dash { get => m_Dash; set => m_Dash = value; }
    public PlayerState Jump { get => m_Jump; set => m_Jump = value; }
    public PlayerState Fall { get => m_Fall; set => m_Fall = value; }
    public PlayerState Land { get => m_Land; set => m_Land = value; }

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
