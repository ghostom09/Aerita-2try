using Unity.VisualScripting;
using UnityEngine;

public class JumpState : EnemyBaseState
{
    public JumpState(Enemy enemy) : base(enemy) { }
    public override void OnEnter()
    {
        Debug.Log("Jump Enter");
        enemy.rb.linearVelocityY = enemy.stat.jumpHeight;
        enemy.stateMachine.ChangeState(new MoveState(enemy));
    }


    public override void OnExit()
    {
        Debug.Log("Jump Exit");
    }
    
}
