using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class TrifolioUtils
{
    public static GameObject thegameObject;

#if UNITY_EDITOR
    [UnityEditor.MenuItem("Ebac/Test")]
    public static void test()
    {
        Debug.Log("teste1");
    }


    [UnityEditor.MenuItem("Ebac/Test2 %e")]
    public static void test2()
    {

        var a = (thegameObject);
        a.transform.position = new Vector3(0, 0, 0);
        Debug.Log("teste2");
    }
#endif

    public static void scaleProgram(this Transform t, float size = 1.2f)
    {
        t.localScale = Vector3.one * size;
    }

    public static T GetRandomList<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static List<T> ShuffleList<T>(this List<T> list, int RandomX = 10)
    {
        System.Random random = new System.Random();
        int a = 1;
        int b = 2;
        while (RandomX > 1)
        {
            a = Random.Range(0, list.Count);
            b = Random.Range(0, list.Count);
            RandomX--;
            //int k = random.Next(RandomX + 1);
            T value = list[a];
            list[a] = list[b];
            list[b] = value;
        }

        return list;
    }
}
