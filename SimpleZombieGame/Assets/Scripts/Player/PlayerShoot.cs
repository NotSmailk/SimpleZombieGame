using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

public class PlayerShoot
{
    private float _cooldown = 0.5f;
    private float _damage;
    private bool _isReloading;
    private UnityEvent _onGunFire;
    private Transform _shootPoint;
    private Transform _transform;
    private Bullet _bullet;

    public void Initialize(Transform transform, Transform shootPoint, Bullet bullet, float damage, UnityEvent onGunFire)
    {
        _transform = transform;
        _onGunFire = onGunFire;
        _shootPoint = shootPoint;
        _bullet = bullet;
        _damage = damage;
    }

    public void GameUpdate()
    {
        Shoot();
    }

    private void Shoot()
    {
        if (_isReloading)
            return;

        Bullet bullet = GameObject.Instantiate(_bullet, _shootPoint.position, Quaternion.identity);
        bullet.Launch(_transform.forward, _damage);
        _onGunFire.Invoke();

        Reload(_cooldown);
    }

    private async void Reload(float cooldown)
    {
        _isReloading = true;
        cooldown *= 1000;
        await Task.Delay((int)cooldown);
        _isReloading = false;
    }
}
