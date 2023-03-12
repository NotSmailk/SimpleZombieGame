using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [field: SerializeField] private AudioSource _audioSource;
    [field: SerializeField] private Collider _collider;
    [field: SerializeField] private Animator _animator;
    [field: SerializeField] private Transform _shootPoint;

    private float _health;

    private PlayerShoot _shoot;
    private PlayerAnimationHandler _animationHandler;
    private PlayerRotation _rotation;
    private PlayerSFX _sfx;

    public UnityEvent OnGunFire { get; } = new UnityEvent();
    public UnityEvent OnGetHit { get; } = new UnityEvent();
    public float Health => _health;
    public PlayerFactory OriginFactory { get; set; }

    public void Initialize(PlayerData data)
    {
        _health = data.Health;

        _animationHandler = new PlayerAnimationHandler();
        _rotation = new PlayerRotation();
        _sfx = new PlayerSFX();
        _shoot = new PlayerShoot();

        _animationHandler.Initialize(_animator);
        _rotation.Initialize(transform);
        _sfx.Initialize(_audioSource, data.Sounds);
        _shoot.Initialize(transform, _shootPoint, data.BulletPrefab, data.Damage, OnGunFire);

        OnGunFire.AddListener(_sfx.PlayGunFireClip);
        OnGetHit.AddListener(_sfx.PlayHitCLip);
        OnGetHit.AddListener(Game.UpdateHealth);
    }

    public void GameUpdate()
    {
        if (_health <= 0)
        {
            DestroyPlayer();
            return;
        }

        _rotation.GameUpdate();
        _shoot.GameUpdate();
    }

    public void DestroyPlayer()
    {
        _animationHandler.PlayDeath();
        Game.Defeat();
        OriginFactory.Reclaim(this, 3f);
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
        OnGetHit.Invoke();
    }
}
