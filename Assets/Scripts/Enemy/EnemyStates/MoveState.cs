using UnityEngine;

public class MoveState : EnemyBaseState
{
    public MoveState(Enemy enemy) : base(enemy) { }
    public override void OnEnter()
    {
        Debug.Log("Move Enter");
    }

    public override void OnUpdate()
    {
        Debug.Log("Move Update");
        enemy.rb.MovePosition(Vector2.MoveTowards(enemy.rb.position,enemy.target.position, enemy.stat.moveSpeed * Time.deltaTime));
        if (Vector2.Distance(enemy.target.position, enemy.transform.position) > enemy.stat.ignoreRange)
        {
            enemy.stateMachine.ChangeState(new IdleState(enemy));
        }
    }

    public override void OnExit()
    {
        Debug.Log("Move Exit");
    }
}
