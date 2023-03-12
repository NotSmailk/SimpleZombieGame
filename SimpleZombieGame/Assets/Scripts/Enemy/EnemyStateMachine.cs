using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine
{
    private EnemyState _currentState;
    private EnemyState _idleState;
    private EnemyState _chaseState;
    private EnemyState _attackState;

    public UnityEvent OnIdle { get; private set; }
    public UnityEvent OnChase { get; private set; }
    public UnityEvent OnAttack { get; private set; }
    public UnityEvent OnDeath { get; private set; }
    public bool IsActive { get; set; }
    public bool IsAttack { get; set; }
    public EnemyState IdleState { get => _idleState; }
    public EnemyState ChaseState { get => _chaseState; }
    public EnemyState AttackState { get => _attackState; }

    public void Initialize(UnityEvent onIdle, UnityEvent onAttack, UnityEvent onChase, UnityEvent onDeath, Transform transform, Rigidbody body, float speed)
    {
        OnAttack = onAttack;
        OnChase = onChase;
        OnIdle = onIdle;
        OnDeath = onDeath;

        _attackState = new EnemyAttackState();
        _idleState = new EnemyIdleState();
        _chaseState = new EnemyChaseState();

        _idleState.Initialize(this, body, transform, speed);
        _chaseState.Initialize(this, body, transform, speed);
        _attackState.Initialize(this, body, transform, speed);

        _currentState = _idleState;
    }

    public void GameUpdate()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        IsActive = Game.Player != null;

        EnemyState nextState = _currentState?.RunCurrentState();

        if (nextState == null)
            return;

        SwitchToNextState(nextState);
    }

    private void SwitchToNextState(EnemyState nextState)
    {
        _currentState = nextState;
    }
}
