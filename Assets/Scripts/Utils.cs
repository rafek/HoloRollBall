using HoloToolkit.Unity.InputModule;
using UnityEngine;

public static class Utils
{
    public static bool IsFloorPointed(out Vector3 focusPoint)
    {
        var focusDetails = FocusManager.Instance.GetFocusDetails(GazeManager.Instance);
        var angle = Vector3.Angle(focusDetails.Normal, Vector3.up);

        focusPoint = focusDetails.Point;

        return angle <= 15.0f;
    }
}
