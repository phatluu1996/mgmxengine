public abstract class AbstractState : IState
{
    private float m_WaitTime;
    public float WaitTime { get => m_WaitTime; set => m_WaitTime = value; }
    private bool m_AnimationFinish;
    public bool AnimationFinish { get => m_AnimationFinish; set => m_AnimationFinish = value; }

    public AbstractState(float waitTime, bool animationFinish)
    {
        m_WaitTime = waitTime;
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