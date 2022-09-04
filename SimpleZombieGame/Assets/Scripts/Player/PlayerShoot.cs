using System.Threading.Tasks;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [field: SerializeField] private Bullet m_bullet;
    [field: SerializeField] Transform m_shootPoint;

    private float m_cooldown = 0.5f;
    private bool m_isReloading;
    private PlayerComponents m_component;

    private void Awake()
    {
        m_component = GetComponent<PlayerComponents>();
    }

    private void Update()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (m_isReloading)
            return;

        Bullet bullet = Instantiate(m_bullet, m_shootPoint.position, Quaternion.identity);

        bullet.Launch(transform.forward, 1);

        m_component.PlayerSoundEffects.OnGunFire.Invoke();

        Reload(m_cooldown);
    }

    private async void Reload(float cooldown)
    {
        m_isReloading = true;

        cooldown *= 1000;

        await Task.Delay((int)cooldown);

        m_isReloading = false;
    }
}
