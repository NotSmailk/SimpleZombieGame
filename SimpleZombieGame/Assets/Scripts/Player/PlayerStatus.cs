using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [field: SerializeField] private float m_hp = 1f;

    public float HP { get => m_hp; }

    private PlayerComponents m_components;

    private void Awake()
    {
        m_components = GetComponent<PlayerComponents>();
    }

    public void GetDamage(float damage)
    {
        m_hp -= damage;

        m_components.PlayerSoundEffects.OnGetHit.Invoke();

        LevelManager.OnHPChange.Invoke();

        if (m_hp <= 0)
            m_components.DestroyPlayer();
    }
}
