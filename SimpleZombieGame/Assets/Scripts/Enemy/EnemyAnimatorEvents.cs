using UnityEngine;

public class EnemyAnimatorEvents : MonoBehaviour
{
    [field: SerializeField] private Enemy _enemy;

    public void Attack()
    {
        _enemy.Attack();
    }
}
