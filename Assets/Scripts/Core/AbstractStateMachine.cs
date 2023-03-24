using System;

public abstract class AbstractStateMachine<T> where T : AbstractState
{
    private T m_CurrentState;
    public T CurrentState { get => m_CurrentState; set => m_CurrentState = value; }
     private T m_PrevState;  
    public T PrevState { get => m_PrevState; set => m_PrevState = value; }
    public abstract void Init(T nextState);
    public abstract void To(T nextState);
    public abstract void To(T nextState, Action<AbstractStateMachine<T>> callback);
    public abstract void To(T nextState, bool stopAttack);
    public abstract void To(T nextState, bool stopAttack, Action<AbstractStateMachine<T>> callback);
    public abstract void To(T nextState, float normalizeTime, bool stopAttack);
    public abstract void To(T nextState, float normalizeTime, bool stopAttack, Action<AbstractStateMachine<T>> callback);
}