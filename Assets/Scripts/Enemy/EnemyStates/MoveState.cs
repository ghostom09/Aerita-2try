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
        enemy.rb.linearVelocityX = Mathf.Sign(enemy.target.position.x - enemy.transform.position.x) * enemy.stat.moveSpeed;
        if (Vector2.Distance(enemy.target.position, enemy.transform.position) > enemy.stat.ignoreRange)
        {
            enemy.stateMachine.ChangeState(new IdleState(enemy));
        }

        if ((enemy.target.position - enemy.transform.position).sqrMagnitude < enemy.stat.range * enemy.stat.range)
        {
            enemy.stateMachine.ChangeState(new AttackState(enemy));   
        }
        if (Physics2D.OverlapBox(enemy.transform.position, new Vector2(1.5f, 0.5f), 0, LayerMask.GetMask("Ground")) && Physics2D.OverlapBox(enemy.transform.position, new Vector2(0.7f,1.1f), 0, LayerMask.GetMask("Ground"))) 
        {
            enemy.stateMachine.ChangeState(new JumpState(enemy));
        }
    }
   
    
    
    public override void OnExit()
    {
        Debug.Log("Move Exit");
    }
}
