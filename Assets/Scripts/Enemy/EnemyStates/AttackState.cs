using UnityEngine;

public class AttackState : EnemyBaseState
{
    private GameObject player;
    private Player_Defense playerScript;

    private float lastAttackTime;
    public AttackState(Enemy enemy) : base(enemy) { }
    public override void OnEnter()
    {
        enemy.rb.linearVelocity = Vector2.zero;
        Debug.Log("Attack Enter");
        player = GameObject.FindGameObjectWithTag("Player");  
        if(player != null)
            playerScript = player.GetComponent<Player_Defense>();
    }

    public override void OnUpdate()
    {
        
        Debug.Log("Attack Update");

        if (Time.time - lastAttackTime > enemy.stat.attackCoolTime)
        {
            enemy.AttackPlayer(playerScript);
            lastAttackTime = Time.time;
        }
        
        
        if ((enemy.transform.position - enemy.target.position).sqrMagnitude > enemy.stat.range * enemy.stat.range + 1)
        {
            enemy.stateMachine.ChangeState(new MoveState(enemy));   
        }
    }

    public override void OnExit()
    {
        Debug.Log("Attack Exit");
    }
}
