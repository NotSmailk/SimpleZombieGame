using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        _stateMachine.OnChase.Invoke();

        if (!_stateMachine.IsActive)
        {
            _body.velocity = Vector3.zero;
            return _stateMachine.IdleState;
        }

        _transform.LookAt(Game.Player.transform);
        _body.velocity = _transform.forward * _speed;

        if (Game.Player == null)
        {
            _body.velocity = Vector3.zero;
            return _stateMachine.IdleState;
        }

        _stateMachine.IsAttack = Vector3.Distance(_transform.position, Game.Player.transform.position) <= 1f;

        if (_stateMachine.IsAttack)
        {
            _body.velocity = Vector3.zero;
            return _stateMachine.AttackState;
        }

        return this;
    }
}
