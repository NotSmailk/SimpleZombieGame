using UnityEngine;

public class EnemyStateManager : MonoBehaviour
{
    [field: SerializeField] private EnemyState m_currentState;
    [field: SerializeField] private EnemyState m_idleState;
    [field: SerializeField] private EnemyState m_chaseState;
    [field: SerializeField] private EnemyState m_attackState;

    public bool IsActive { get; set; }
    public bool IsAttack { get; set; }
    public EnemyState IdleState { get => m_idleState; }
    public EnemyState ChaseState { get => m_chaseState; }
    public EnemyState AttackState { get => m_attackState; }

    private EnemyComponents m_components;

    private void Awake()
    {
        m_components = GetComponent<EnemyComponents>();

        m_idleState.SetComponents(m_components);
        m_chaseState.SetComponents(m_components);
        m_attackState.SetComponents(m_components);
    }

    private void Update()
    {
        RunStateMachine();
    }

    private void RunStateMachine()
    {
        IsActive = LevelManager.Player != null;

        EnemyState nextState = m_currentState?.RunCurrentState();

        if (nextState == null)
            return;

        SwitchToNextState(nextState);
    }

    private void SwitchToNextState(EnemyState nextState)
    {
        m_currentState = nextState;

        m_currentState.SetComponents(m_components);
    }
}
