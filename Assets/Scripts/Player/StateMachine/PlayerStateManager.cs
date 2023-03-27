using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class PlayerStateManager
{
    [SerializeField]
    private PlayerState m_BeamDown;
    [SerializeField]
    private PlayerIdleState m_Idle;
    [SerializeField]
    private PlayerCrouchState m_Crouch;
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
    [SerializeField]
    private PlayerWallSlideState m_WallSlide;
    [SerializeField]
    private PlayerWallJumpState m_WallJump;
    [SerializeField]
    private PlayerClimbUpLadderState m_ClimbLadderUp;
    [SerializeField]
    private PlayerClimbDownLadderState m_ClimbLadderDown;
    [SerializeField]
    private PlayerClimbLadderState m_ClimbLadder;

    public PlayerState BeamDown { get => m_BeamDown; set => m_BeamDown = value; }
    public PlayerIdleState Idle { get => m_Idle; set => m_Idle = value; }
    public PlayerCrouchState Crouch { get => m_Crouch; set => m_Crouch = value; }
    public PlayerRunState Run { get => m_Run; set => m_Run = value; }
    public PlayerDashState Dash { get => m_Dash; set => m_Dash = value; }
    public PlayerJumpState Jump { get => m_Jump; set => m_Jump = value; }
    public PlayerFallState Fall { get => m_Fall; set => m_Fall = value; }
    public PlayerLandState Land { get => m_Land; set => m_Land = value; }
    public PlayerWallSlideState WallSlide { get => m_WallSlide; set => m_WallSlide = value; }
    public PlayerWallJumpState WallJump { get => m_WallJump; set => m_WallJump = value; }
    public PlayerClimbUpLadderState ClimbLadderUp { get => m_ClimbLadderUp; set => m_ClimbLadderUp = value; }
    public PlayerClimbDownLadderState ClimbLadderDown { get => m_ClimbLadderDown; set => m_ClimbLadderDown = value; }
    public PlayerClimbLadderState ClimbLadder { get => m_ClimbLadder; set => m_ClimbLadder = value; }
    public PlayerStateManager(PlayerStateMachine stateMachine, Player player, SpriteSetsManager spriteSetsManager)
    {
        m_Idle = new PlayerIdleState(stateMachine, player, spriteSetsManager.Idle);
        m_Crouch = new PlayerCrouchState(stateMachine, player, spriteSetsManager.Crouch);
        m_Run = new PlayerRunState(stateMachine, player, spriteSetsManager.Run);
        m_Dash = new PlayerDashState(stateMachine, player, spriteSetsManager.Dash);
        m_Jump = new PlayerJumpState(stateMachine, player, spriteSetsManager.Jump);
        m_Fall = new PlayerFallState(stateMachine, player, spriteSetsManager.Fall);
        m_Land = new PlayerLandState(stateMachine, player, spriteSetsManager.Land);
        m_WallSlide = new PlayerWallSlideState(stateMachine, player, spriteSetsManager.WallSlide);
        m_WallJump = new PlayerWallJumpState(stateMachine, player, spriteSetsManager.WallJump);
        m_ClimbLadder = new PlayerClimbLadderState(stateMachine, player, spriteSetsManager.ClimbLadder);
        m_ClimbLadderUp = new PlayerClimbUpLadderState(stateMachine, player, spriteSetsManager.ClimbLadderUp);
        m_ClimbLadderDown = new PlayerClimbDownLadderState(stateMachine, player, spriteSetsManager.ClimbLadderDown);
    }
}
