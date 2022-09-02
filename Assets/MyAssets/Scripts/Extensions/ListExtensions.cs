using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ListExtensions
{
    public static bool isNull<T>(this List<T> myList)
    {
        if (myList.Count == 0)
        {
            return true;
        }
        return false;
    }

    public static T RemoveLast<T>(this List<T> ts)
    {
        T temp = ts[ts.Count - 1];
        ts.Remove(temp);
        return temp;
    }
}
