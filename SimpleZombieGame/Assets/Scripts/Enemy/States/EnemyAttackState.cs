using UnityEngine;
using System.Threading.Tasks;

public class EnemyAttackState : EnemyState
{
    private int m_damage = 1;
    private bool m_onCooldown = false;

    public override EnemyState RunCurrentState()
    {
        m_components.EnemyAnimator.PlayAttack();

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
            Attack();

            return this;
        }

        return m_components.EnemyStateManager.IsActive ? m_components.EnemyStateManager.ChaseState : m_components.EnemyStateManager.IdleState;
    }

    private void Attack()
    {
        if (m_onCooldown || LevelManager.Player == null)
            return;

        m_components.EnemySoundEffects.PlayAttackCLip();

        LevelManager.Player.PlayerStatus.GetDamage(m_damage);

        Cooldown(m_components.EnemyAnimator.GetCurrentAnimationTime());
    }

    private async void Cooldown(float cooldown)
    {
        m_onCooldown = true;

        cooldown *= 1000;

        await Task.Delay((int)cooldown);

        m_onCooldown = false;
    }
}
