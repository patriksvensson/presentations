using System;

namespace Demo.Framework;

public static class ListExtensions
{
    public static void Shuffle<T>(this IList<T> list)
    {
        var n = list.Count;
        while (n > 1)
        {
            n--;
            var k = Random.Shared.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }

    public static T GetRandom<T>(this IList<T> list)
    {
        return list[Random.Shared.Next(list.Count)];
    }
}
