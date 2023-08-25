using UnityEngine;

public class EnemyAttackState : IEnemyState, IEnterable
{
    private bool _onCooldown = false;
    protected Transform _transform;
    protected Rigidbody _body;
    protected float _speed;

    public EnemyStateMachine Initializer { get; }

    public EnemyAttackState(EnemyStateMachine stateMachine, Rigidbody body, Transform transform, float speed)
    {
        Initializer = stateMachine;
        _body = body;
        _transform = transform;
        _speed = speed;
    }

    public void Run()
    {
        bool isAttack = Game.Player != null && Vector3.Distance(_transform.position, Game.Player.transform.position) <= 1f;

        if (!isAttack)
        {
            Initializer.SwitchState<EnemyIdleState>();
            return;
        }

        Attack();
    }

    private void Attack()
    {
        if (_onCooldown)
            return;

        Initializer.OnAttack?.Invoke();
    }

    public void Enter()
    {
        _body.velocity = Vector3.zero;
    }
}
