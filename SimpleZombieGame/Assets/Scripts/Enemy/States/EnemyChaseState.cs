using UnityEngine;

public class EnemyChaseState : IEnemyState, IEnterable
{
    protected Rigidbody _body;
    protected Transform _transform;
    protected float _speed;

    public EnemyStateMachine Initializer { get; }

    public EnemyChaseState(EnemyStateMachine stateMachine, Rigidbody body, Transform transform, float speed)
    {
        Initializer = stateMachine;
        _body = body;
        _transform = transform;
        _speed = speed;
    }

    public void Run()
    {
        if (Game.Player == null)
        {
            Initializer.SwitchState<EnemyIdleState>();
            return;
        }

        _transform.LookAt(Game.Player.transform);
        _body.velocity = _transform.forward * _speed;

        bool isAttack = Vector3.Distance(_transform.position, Game.Player.transform.position) <= 1f;

        if (isAttack)
        {
            Initializer.SwitchState<EnemyAttackState>();
            return;
        }
    }

    public void Enter()
    {
        Initializer.OnChase?.Invoke();
    }
}
