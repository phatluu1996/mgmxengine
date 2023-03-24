using System;

public class PlayerStateMachine : AbstractStateMachine<PlayerState>
{

    public PlayerStateMachine()
    {
    }

    public override void Init(PlayerState nextState){
        CurrentState = nextState;
        PrevState  = nextState;
        CurrentState.OnEnter();
    }

    public override void To(PlayerState nextState)
    {
        SwapState(nextState);
        CurrentState.OnEnter(false, 0);
    }

    public override void To(PlayerState nextState, bool stopAttack)
    {
        SwapState(nextState);
        CurrentState.OnEnter(stopAttack, 0);
    }

    public override void To(PlayerState nextState, float normalizeTime, bool stopAttack)
    {
        SwapState(nextState);
        CurrentState.OnEnter(stopAttack, normalizeTime);
    }

    public override void To(PlayerState nextState, Action<AbstractStateMachine<PlayerState>> callback)
    {
        SwapState(nextState);
        CurrentState.OnEnter(false, 0);
        callback(this);
    }

    public override void To(PlayerState nextState, bool stopAttack, Action<AbstractStateMachine<PlayerState>> callback)
    {
        SwapState(nextState);
        CurrentState.OnEnter(stopAttack, 0);
        callback(this);
    }    

    public override void To(PlayerState nextState, float normalizeTime, bool stopAttack, Action<AbstractStateMachine<PlayerState>> callback)
    {
        SwapState(nextState);
        CurrentState.OnEnter(stopAttack, normalizeTime);
        callback(this);
    }

    private void SwapState(PlayerState nextState){
        PrevState = CurrentState;
        CurrentState = nextState;    
        PrevState.OnExit();          
    }
}