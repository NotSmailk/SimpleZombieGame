using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    protected EnemyComponents m_components;

    public void SetComponents(EnemyComponents components)
    {
        if (components == m_components)
            return;

        m_components = components;
    }

    public abstract EnemyState RunCurrentState();
}
