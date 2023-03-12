using Newtonsoft.Json.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class GameInputs : MonoBehaviour
{
    public static int RightMoveValue = 0;
    public static int LeftMoveValue = 0;

    public static void SetRightRotateValue(int value)
    {
        RightMoveValue = value;
    }

    public static void SetLeftRotateValue(int value)
    {
        LeftMoveValue = value;
    }
}
