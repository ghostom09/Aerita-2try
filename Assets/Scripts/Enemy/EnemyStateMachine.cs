using UnityEngine;

public class EnemyStateMachine
{
    public EnemyBaseState CurrentState { get; private set; }

    public void ChangeState(EnemyBaseState newState)
    {
        CurrentState?.OnExit();
        CurrentState = newState;
        CurrentState.OnEnter();
    }

    public void Update()
    {
        CurrentState?.OnUpdate();
    }
}
