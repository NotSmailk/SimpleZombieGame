using UnityEngine;

public abstract class EnemyState
{
    protected EnemyStateMachine _stateMachine;
    protected Rigidbody _body;
    protected Transform _transform;
    protected float _speed;

    public void Initialize(EnemyStateMachine stateMachine, Rigidbody body, Transform transform, float speed)
    {
        _stateMachine = stateMachine;
        _body = body;
        _transform = transform;
        _speed = speed;
    }

    public abstract EnemyState RunCurrentState();
}
