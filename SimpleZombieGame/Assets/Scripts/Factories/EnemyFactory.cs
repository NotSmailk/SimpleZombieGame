using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Enemy Factory", fileName = "New Enemy Factory")]
public class EnemyFactory : GameObjectFactory
{
    public Enemy Get(EnemyData data)
    {
        var enemy = CreatObject(data.Prefab);
        enemy.Initialize(data);
        enemy.OriginFactory = this;
        return enemy;
    }

    public void Reclaim(Enemy enemy, float time)
    {
        Destroy(enemy.gameObject, time);
    }
}
