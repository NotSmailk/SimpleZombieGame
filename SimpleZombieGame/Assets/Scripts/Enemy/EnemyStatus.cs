using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [field: SerializeField] private float m_speed = 1f;
    [field: SerializeField] private float m_hp = 2f;

    private EnemyComponents m_components;

    private void Awake()
    {
        m_components = GetComponent<EnemyComponents>();
    }

    public float Speed { get => m_speed; }

    public void GetDamage(float damage)
    {
        m_hp -= damage;

        if (m_hp <= 0)
            m_components.DestroyEnemy();
    }
}
