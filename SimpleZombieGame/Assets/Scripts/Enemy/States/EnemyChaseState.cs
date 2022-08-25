using UnityEngine;

public class EnemyChaseState : EnemyState
{
    public override EnemyState RunCurrentState()
    {
        m_components.EnemyAnimator.PlayChase();

        if (!m_components.EnemyStateManager.IsActive)
        {
            m_components.Rigidbody.velocity = Vector3.zero;

            return m_components.EnemyStateManager.IdleState;
        }

        m_components.transform.LookAt(LevelManager.Player.transform);

        m_components.Rigidbody.velocity = m_components.transform.forward * m_components.EnemyStatus.Speed;

        Collider[] colliders = Physics.OverlapSphere(m_components.transform.position, 1f);

        if (colliders.Length > 0)
        {
            foreach (Collider collider in colliders)
            {
                m_components.EnemyStateManager.IsAttack = collider.GetComponent<PlayerComponents>() != null;

                if (m_components.EnemyStateManager.IsAttack)
                    break;
            }
        }

        if (m_components.EnemyStateManager.IsAttack)
        {
            m_components.Rigidbody.velocity = Vector3.zero;

            return m_components.EnemyStateManager.AttackState;
        }

        return this;
    }
}
