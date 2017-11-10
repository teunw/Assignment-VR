using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public static class Utils {

	public static System.Random random = new System.Random();

    public static T GetRandomElement<T>(this IEnumerable<T> arr)
    {
        var enumerable = arr as T[] ?? arr.ToArray();
        return enumerable.ElementAt(random.Next(0, enumerable.Length - 1));
    }
}
