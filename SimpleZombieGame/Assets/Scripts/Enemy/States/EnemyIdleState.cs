using UnityEngine;

public class EnemyIdleState : IEnemyState, IEnterable
{
    protected Rigidbody _body;

    public EnemyStateMachine Initializer { get; }

    public EnemyIdleState(EnemyStateMachine stateMachine, Rigidbody body)
    {
        Initializer = stateMachine;
        _body = body;
    }

    public void Run()
    {
        if (Game.Player != null)
        {
            Initializer.SwitchState<EnemyChaseState>();
        }    
    }

    public void Enter()
    {
        Initializer.OnIdle?.Invoke();
        _body.velocity = Vector3.zero;
    }
}
