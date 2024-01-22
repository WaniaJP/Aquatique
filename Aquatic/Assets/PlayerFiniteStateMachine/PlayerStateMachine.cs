using UnityEngine;

public class PlayerStateMachine
{
    public PlayerState CurrentState { get; private set; }
    public PlayerState PreviousState { get; private set; }

    public PlayerStateMachine()
    {
       //SecondaryStates = new PlayerSecondaryState[1];
    }

    public void Initialize(PlayerState startingState)
    {
        PreviousState = startingState;
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(PlayerState newState)
    {
        CurrentState.Exit();
        PreviousState = CurrentState;
        CurrentState = newState;
        //Debug.Log("Statemachine : " + PreviousState.GetType().Name + " => " + CurrentState.GetType().Name);
        CurrentState.Enter();
    }
}