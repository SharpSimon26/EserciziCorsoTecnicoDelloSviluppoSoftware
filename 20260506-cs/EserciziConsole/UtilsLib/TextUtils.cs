namespace UtilsLib;

public static class TextUtils
{
    public static string Capitalize(this string str)
    {
        var items = str.Split(' ');
        var resItems = new string[items.Length];

        for (int i = 0; i < items.Length; i++)
        {
            string s1 = items[i].Substring(0, 1);
            string s2 = items[i].Substring(1);
            resItems[i] = s1.ToUpper() + s2;
        }

        return string.Join(' ', resItems);
    }
}
