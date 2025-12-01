using UnityEngine;

public class IdleState : EnemyBaseState
{
    public IdleState(Enemy enemy) : base(enemy) { }
    public override void OnEnter()
    {
        Debug.Log("Idle Enter");
    }

    public override void OnUpdate()
    {
        Debug.Log("Idle Update");
        if (Vector2.Distance(enemy.target.position, enemy.transform.position) < enemy.stat.perceiveRange)
        {
            enemy.stateMachine.ChangeState(new MoveState(enemy));
        }
    }

    public override void OnExit()
    {
        Debug.Log("Idle Exit");
    }
}
