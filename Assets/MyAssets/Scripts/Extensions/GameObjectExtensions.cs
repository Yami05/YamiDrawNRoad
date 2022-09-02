using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public static class GameObjectExtensions
{
    public static void GoSmall(this GameObject obj, float time)
    {
        obj.transform.DOScale(Vector3.zero, time);
    }
}
