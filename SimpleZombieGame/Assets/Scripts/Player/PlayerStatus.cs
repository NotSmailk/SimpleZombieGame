using UnityEngine;

public class PlayerStatus : MonoBehaviour
{
    [field: SerializeField] private int m_hp = 1;

    public int HP { get => m_hp; }

    private PlayerComponents m_components;

    private void Awake()
    {
        m_components = GetComponent<PlayerComponents>();
    }

    public void GetDamage(int damage)
    {
        m_hp -= damage;

        m_components.PlayerSoundEffects.OnGetHit.Invoke();

        LevelManager.OnHPChange.Invoke();

        if (m_hp <= 0)
            m_components.DestroyPlayer();
    }
}
