using UnityEngine;

public class EnemyStatus : MonoBehaviour
{
    [field: SerializeField] private float m_speed = 1f;
    [field: SerializeField] private int m_hp = 2;

    private EnemyComponents m_components;

    private void Awake()
    {
        m_components = GetComponent<EnemyComponents>();
    }

    public float Speed { get => m_speed; }

    public void GetDamage(int damage)
    {
        m_hp -= damage;

        if (m_hp <= 0)
            m_components.DestroyEnemy();
    }
}
