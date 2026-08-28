namespace CompanionStudio.Core.StateMachine;

public class CompanionStateMachine
{
    public CompanionStateType CurrentState { get; private set; }


    public CompanionStateMachine()
    {
        CurrentState =
            CompanionStateType.Idle;
    }


    public void ChangeState(
        CompanionStateType state)
    {
        CurrentState = state;
    }


    public bool Is(
        CompanionStateType state)
    {
        return CurrentState == state;
    }
}