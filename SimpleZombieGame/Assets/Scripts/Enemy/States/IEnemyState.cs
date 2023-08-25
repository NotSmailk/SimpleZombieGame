using UnityEngine;

public interface IEnemyState : IState<EnemyStateMachine>
{
    public void Run();
}
