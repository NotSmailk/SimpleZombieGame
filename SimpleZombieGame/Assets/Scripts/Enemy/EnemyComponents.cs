using UnityEngine;

public class EnemyComponents : MonoBehaviour
{
    [field: HideInInspector] public Collider Collider;
    [field: HideInInspector] public Rigidbody Rigidbody;
    [field: HideInInspector] public EnemyStatus EnemyStatus;
    [field: HideInInspector] public EnemyAnimator EnemyAnimator;
    [field: HideInInspector] public EnemySoundEffects EnemySoundEffects;
    [field: HideInInspector] public EnemyStateManager EnemyStateManager;

    private void Awake()
    {
        Collider = GetComponent<Collider>();

        Rigidbody = GetComponent<Rigidbody>();

        EnemyStatus = GetComponent<EnemyStatus>();

        EnemyAnimator = GetComponent<EnemyAnimator>();

        EnemyStateManager = GetComponent<EnemyStateManager>();

        EnemySoundEffects = GetComponent<EnemySoundEffects>();
    }

    public void DestroyEnemy()
    {
        Rigidbody.velocity = Vector3.zero;
        Collider.enabled = false;
        EnemyStateManager.enabled = false;

        EnemyAnimator.PlayDeath();
        EnemySoundEffects.PlayDeathClip();

        Destroy(gameObject, 3f);

        LevelManager.RemoveEnemy(this);
    }
}
