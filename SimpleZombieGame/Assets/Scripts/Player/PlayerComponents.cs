using UnityEngine;

public class PlayerComponents : MonoBehaviour
{
    [field: HideInInspector] public Collider Collider;
    [field: HideInInspector] public PlayerShoot PlayerShoot;
    [field: HideInInspector] public PlayerStatus PlayerStatus;
    [field: HideInInspector] public PlayerAnimator PlayerAnimator;
    [field: HideInInspector] public PlayerRotation PlayerRotation;
    [field: HideInInspector] public PlayerSoundEffects PlayerSoundEffects;
    
    private void Awake()
    {
        Collider = GetComponent<Collider>();

        PlayerShoot = GetComponent<PlayerShoot>();

        PlayerStatus = GetComponent<PlayerStatus>();

        PlayerRotation = GetComponent<PlayerRotation>();

        PlayerAnimator = GetComponent<PlayerAnimator>();

        PlayerSoundEffects = GetComponent<PlayerSoundEffects>();

        LevelManager.SetPlayer(this);
    }

    public void DestroyPlayer()
    {
        LevelManager.SetPlayer(null);

        Collider.enabled = false;
        PlayerShoot.enabled = false;
        PlayerRotation.enabled = false;
        enabled = false;

        PlayerAnimator.PlayDeath();

        Destroy(gameObject, 3f);
    }
}
