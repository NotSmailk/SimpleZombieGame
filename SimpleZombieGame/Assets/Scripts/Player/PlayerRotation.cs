using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    [field: SerializeField] private float m_rotationSpeed = 5f;

    private PlayerComponents m_components;

    private void Awake()
    {
        m_components = GetComponent<PlayerComponents>();
    }

    private void Update()
    {
        RotatePlayer(GameInputs.LeftMoveValue, GameInputs.RightMoveValue);
    }

    public void RotatePlayer(int leftValue, int rightValue)
    {
        Quaternion rotation = transform.rotation;

        float yAngle = Mathf.Clamp(ClampRotationValue(rotation.eulerAngles.y) + 10f * m_rotationSpeed * (rightValue - leftValue) * Time.deltaTime, -90f, 90f);

        rotation = Quaternion.Euler(rotation.eulerAngles.x, yAngle, rotation.eulerAngles.z);

        transform.rotation = rotation;
    }

    private float ClampRotationValue(float value)
    {
        value = value % 360f;

        if (value > 180)
            value -= 360;
        else if (value < -180)
            value += 360;

        return value;
    }
}
