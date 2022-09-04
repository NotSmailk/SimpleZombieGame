using UnityEngine;

public class EnemyIdleState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        m_components.EnemyAnimator.PlayIdle();

        m_components.Rigidbody.velocity = Vector3.zero;

        return m_components.EnemyStateManager.IsActive ? m_components.EnemyStateManager.ChaseState : this;
    }
}
