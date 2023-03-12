using UnityEngine;

[CreateAssetMenu(menuName = "Factories/Player Factory", fileName = "New Player Factory")]
public class PlayerFactory : GameObjectFactory
{
    public Player Get(PlayerData data)
    {
        var player = CreatObject(data.Prefab);
        player.Initialize(data);
        player.OriginFactory = this;
        return player;
    }

    public void Reclaim(Player player, float time)
    {
        Destroy(player);
        Destroy(player.gameObject, time);
    }
}
