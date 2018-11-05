using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static partial class GameObjectExensions
 {
    public static bool HasChild(this GameObject gameObject)
    {
        return 0 < gameObject.transform.childCount;
    }
 }

public static partial class TrabsformExtensions
{
    public static bool HasChild(this Transform transform)
    {
        return 0 < transform.childCount;
    }
}

