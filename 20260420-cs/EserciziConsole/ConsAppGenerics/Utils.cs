namespace ConsAppGenerics;

internal static class Utils
{
    public static int GetIndex<T>(T[] arr, T value)
    {
        return arr.IndexOf(value);
    }

    public static T[] Sort<T>(T[] arr) where T: IComparable
    {
        bool run = true;

        while (run)
        {
            run = false;
            for (int i = 1; i < arr.Length; i++)
            {
                if (arr[i -1].CompareTo(arr[i]) > 0)
                {
                    T tmp = arr[i];
                    arr[i] = arr[i -1];
                    arr[i -1] = tmp;
                    run = true;
                }
            }
        }

        return arr;
    }

    public static TOut Foo<TIn, TOut>(TIn pippo) where TIn : class
    {
        // where TIn : class
        // where TIn : struct
        // where TOut : new() <-- deve avere costruttore senza parametri, ritorna new TOut() 
        // where TIn : struct where TOut : new()  <- concatena 2 where
        throw new NotImplementedException();
    }
}