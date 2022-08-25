using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInputs : MonoBehaviour
{
    public static int RightMoveValue = 0;
    public static int LeftMoveValue = 0;

    public void SetRightRotateValue(int value)
    {
        RightMoveValue = value;
    }

    public void SetLeftRotateValue(int value)
    {
        LeftMoveValue = value;
    }
}
