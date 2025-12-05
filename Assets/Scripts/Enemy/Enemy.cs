using System;
using Unity.VisualScripting;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public state stat;
    public EnemyStateMachine stateMachine;
    public Transform target;
    public Rigidbody2D rb;
    private void Awake()
    {
        stateMachine = new EnemyStateMachine();
        stat.currentHp = stat.hp;
    }
    
    void Start()
    {
        stateMachine.ChangeState(new IdleState(this)); // 처음 상태: 도움 요청
    }
    void Update()
    {
        stateMachine.Update();
    }

    public void AttackPlayer(Player_Defense playerD)
    {
        playerD.Hit(stat.damage);
    }
}

[Serializable]
public class state
{
    [Header("basic stat")] 
    public float hp;
    public float currentHp;
    public float damage;
    public float range;
    public float attackCoolTime;

    [Header("movement stat")] 
    public float moveSpeed;
    public float jumpHeight;

    [Header("other stat")]
    public float perceiveRange;
    public float ignoreRange;
}
