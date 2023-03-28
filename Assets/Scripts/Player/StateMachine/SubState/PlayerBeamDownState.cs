using UnityEngine;

public class PlayerBeamDownState : PlayerState
{
    private Vector2 m_originPosition;
    private Vector2 m_BeamDownPosition;
    public PlayerBeamDownState(PlayerStateMachine stateMachine, Player player, SpriteDataSet spriteDataSet) : base(stateMachine, player, spriteDataSet)
    {
    }

    public override void OnEnter()
    {
        base.OnEnter();
    }

    public override void OnEnter(bool stopAttack, float normalizeTime)
    {
        base.OnEnter(stopAttack, normalizeTime);
        CameraEngine.Instance.m_FollowModule.JumpToTarget();
        Player.Controller.enabled = false;
        m_originPosition = Player.Position;
        Player.y += 300;
        m_BeamDownPosition = Player.Position;
        VelocicyX = 0;
        VelocicyY = -Physics.JumpSpeed;
    }

    public override void OnExit()
    {
        base.OnExit();
        Animator.SetBool("beam_transform", false);
    }

    public override void OnUpdate()
    {
        base.OnUpdate();
        if (!Animator.GetBool("beam_transform"))
        {
            Timer += (Time.deltaTime * Physics.BeamDownSpeed * Application.targetFrameRate)/
                             Vector2.Distance(m_originPosition, m_BeamDownPosition);
            Vector2 newPosition = Vector2.Lerp(m_BeamDownPosition, m_originPosition, Timer);
            
            Player.transform.Translate(newPosition - Player.Position);
            if (Timer >= 1)
            {
                Animator.SetBool("beam_transform", true);
                Player.Position = m_originPosition;
            }
        }
        else
        {
            if (AnimationFinish)
            {
                Player.Controller.collisions.below = true;
                Player.Controller.enabled = true;
                CameraEngine.Instance.m_FollowModule.Enable = true;
                StateMachine.To(States.Idle);
                return;
            }
        }
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