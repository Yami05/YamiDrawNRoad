using UnityEngine;
using System.Collections;

public static class TransformExtensions
{
    public static void ClampX(this Transform pos, float a, float b)
    {
        float x = Mathf.Clamp(pos.position.x, a, b);

        pos.position = new Vector3(x, pos.position.y, pos.position.z);
    }
}
