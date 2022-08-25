using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    private float m_speed = 5f;
    private float m_damage = 1f;

    public void Launch(Vector3 direction, float damage)
    {
        GetComponent<Rigidbody>().velocity = direction * m_speed;

        m_damage = damage;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out EnemyComponents enemy))
            enemy.EnemyStatus.GetDamage(m_damage);

        Destroy(gameObject);
    }
}
