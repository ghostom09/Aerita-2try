using UnityEngine;

public abstract class EnemyBaseState
{
    protected Enemy enemy;
    
    public EnemyBaseState(Enemy enemy)
    {
        this.enemy = enemy;
    }

    public virtual void OnEnter() {}
    public virtual void OnUpdate() {}
    public virtual void OnExit() {}
    
}
