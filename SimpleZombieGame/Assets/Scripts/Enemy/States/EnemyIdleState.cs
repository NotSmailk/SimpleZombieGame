using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        _stateMachine.OnIdle.Invoke();
        _body.velocity = Vector3.zero;
        return _stateMachine.IsActive ? _stateMachine.ChaseState : this;
    }
}
