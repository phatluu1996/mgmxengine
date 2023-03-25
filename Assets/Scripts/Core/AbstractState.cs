public abstract class AbstractState : IState
{
    private float m_Timer;
    public float Timer { get => m_Timer; set => m_Timer = value; }
    private bool m_AnimationFinish;
    public bool AnimationFinish { get => m_AnimationFinish; set => m_AnimationFinish = value; }

    public AbstractState(float Timer, bool animationFinish)
    {
        m_Timer = Timer;
        m_AnimationFinish = animationFinish;
    }

    public AbstractState()
    {

    }

    public abstract void OnEnter();
    public abstract void OnEnter(bool stopAttack, float normalizeTime);
    public abstract void OnExit();

    public abstract void OnUpdate();

    public abstract void OnFinish(int index);

    public abstract void OnTrigger(int index);
}