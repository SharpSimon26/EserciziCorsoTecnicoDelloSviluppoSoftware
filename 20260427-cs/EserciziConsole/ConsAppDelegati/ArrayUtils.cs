namespace ConsAppDelegati;

internal static class ArrayUtils
{
    public static T2[] Map<T1, T2>(T1[] arr, Func<T1, T2> piero)
    {
        var ris = new T2[arr.Length];

        for (int i = 0; i < arr.Length; i++)
        {
            T1 v = arr[i];
            ris[i] = piero(v);
        }

        return ris;
    }

    public static T[] Filter<T>(T[] arr, Func<T, bool> piero)
    {
        var ris = new List<T>();

        foreach (var item in arr)
        {
            if (piero(item))
            {
                ris.Add(item);
            }
        }

        return ris.ToArray();
    }

    /*
    public static int[] Map(int[] arr, Func<int, int> piero)
    {
        var ris = new int[arr.Length];

        for (int i = 0; i < ris.Length; i++)
        {
            ris[i] = piero(arr[i]);
        }

        return ris;
    }
    */

    /*
    public static int[] Map(int[] arr)
    {
        var ris = new int[arr.Length];

        for (int i = 0; i < ris.Length; i++)
        {
            ris[i] = arr[i] * 2;
        }

        return ris;
    }
    */
}