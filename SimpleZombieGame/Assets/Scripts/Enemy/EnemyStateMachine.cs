using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyStateMachine
{
    private IEnemyState _curState;
    private Dictionary<Type, IEnemyState> _states = new Dictionary<Type, IEnemyState>();

    public UnityEvent OnIdle { get; private set; }
    public UnityEvent OnChase { get; private set; }
    public UnityEvent OnAttack { get; private set; }
    public UnityEvent OnDeath { get; private set; }

    public void Initialize(UnityEvent onIdle, UnityEvent onAttack, UnityEvent onChase, UnityEvent onDeath, Transform transform, Rigidbody body, float speed)
    {
        OnAttack = onAttack;
        OnChase = onChase;
        OnIdle = onIdle;
        OnDeath = onDeath;

        var attackState = new EnemyAttackState(this, body, transform, speed);
        var idleState = new EnemyIdleState(this, body);
        var chaseState = new EnemyChaseState(this, body, transform, speed);

        _states.Add(attackState.GetType(), attackState);
        _states.Add(idleState.GetType(), idleState);
        _states.Add(chaseState.GetType(), chaseState);

        _curState = idleState;
    }

    public void GameUpdate()
    {
        _curState.Run();
    }

    public void SwitchState<TEnemyState>() where TEnemyState : IEnemyState
    {
        // Try get new state
        if (_states.TryGetValue(typeof(TEnemyState), out IEnemyState state))
            _curState = (TEnemyState)state;

        // Try enter new state
        if (_curState is IEnterable enterable)
            enterable.Enter();
    }
}
