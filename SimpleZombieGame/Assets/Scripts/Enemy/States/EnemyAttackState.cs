using UnityEngine;
using System.Threading.Tasks;

public class EnemyAttackState : EnemyState
{
    private bool _onCooldown = false;

    public override EnemyState RunCurrentState()
    {
        if (Game.Player == null)
            return _stateMachine.IdleState;

        _stateMachine.OnAttack.Invoke();
        _stateMachine.IsAttack = Vector3.Distance(_transform.position, Game.Player.transform.position) <= 1f;

        if (_stateMachine.IsAttack)
        {
            Attack();

            return this;
        }

        return _stateMachine.IsActive ? _stateMachine.ChaseState : _stateMachine.IdleState;
    }

    private void Attack()
    {
        if (_onCooldown || Game.Player == null)
            return;

        _stateMachine.OnAttack.Invoke();
    }
}
