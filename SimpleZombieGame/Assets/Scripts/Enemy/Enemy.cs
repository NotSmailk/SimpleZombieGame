using UnityEngine;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
    [field: SerializeField] private Animator _animator;
    [field: SerializeField] private AudioSource _audioSource;
    [field: SerializeField] private Collider _collider;
    [field: SerializeField] private Rigidbody _rigidbody;

    private float _health;
    private float _damage;

    private EnemyAnimationHandler _animationHandler;
    private EnemySFX _sfx;
    private EnemyStateMachine _stateMachine;

    public UnityEvent OnIdle { get; } = new UnityEvent();
    public UnityEvent OnChase { get; } = new UnityEvent();
    public UnityEvent OnAttack { get; } = new UnityEvent();
    public UnityEvent OnDeath { get; } = new UnityEvent();
    public EnemyFactory OriginFactory { get; set; }

    public void Initialize(EnemyData data)
    {
        _health = data.Health;
        _damage = data.Damage;

        _sfx = new EnemySFX();
        _stateMachine = new EnemyStateMachine();
        _animationHandler = new EnemyAnimationHandler();

        _stateMachine.Initialize(OnIdle, OnAttack, OnChase, OnDeath, transform, _rigidbody, data.Speed);
        _animationHandler.Initialize(_animator);
        _sfx.Initialize(_audioSource, data.Sounds);

        OnDeath.AddListener(_sfx.PlayDeathClip);

        OnDeath.AddListener(_animationHandler.PlayDeath);
        OnAttack.AddListener(_animationHandler.PlayAttack);
        OnIdle.AddListener(_animationHandler.PlayIdle);
        OnChase.AddListener(_animationHandler.PlayChase);
    }

    public bool GameUpdate()
    {
        if (_health <= 0)
        {
            DestroyEnemy();
            return false;
        }

        _stateMachine.GameUpdate();

        return true;
    }

    public void DestroyEnemy()
    {
        _animationHandler.PlayDeath();
        _sfx.PlayDeathClip();
        _collider.enabled = false;
        _rigidbody.velocity = Vector3.zero;
        OriginFactory.Reclaim(this, 3f);
    }

    public void GetDamage(float damage)
    {
        _health -= damage;
    }

    public void Attack()
    {
        _sfx.PlayAttackCLip();
        Game.Player?.GetDamage(_damage);
    }
}
