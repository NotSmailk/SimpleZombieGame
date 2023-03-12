using UnityEngine;

public class PlayerRotation
{
    [field: SerializeField] private float _rotationSpeed = 5f;

    private Transform _transform;

    public void Initialize(Transform transform)
    {
        _transform = transform;
    }

    public void GameUpdate()
    {
        RotatePlayer(GameInputs.LeftMoveValue, GameInputs.RightMoveValue);
    }

    public void RotatePlayer(int leftValue, int rightValue)
    {
        Quaternion rotation = _transform.rotation;

        float rotationDelta = ClampRotationValue(rotation.eulerAngles.y) + 10f * _rotationSpeed * (rightValue - leftValue) * Time.deltaTime;
        float yAngle = Mathf.Clamp(rotationDelta, -90f, 90f);

        rotation = Quaternion.Euler(rotation.eulerAngles.x, yAngle, rotation.eulerAngles.z);
        _transform.rotation = rotation;
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
