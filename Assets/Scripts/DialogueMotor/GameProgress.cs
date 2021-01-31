using UnityEngine;

public static class GameProgress
{
    public static bool Has(string progress)
    {
        return PlayerPrefs.GetInt(progress, 0) == 1;
    }

    public static bool HasNot(string progress)
    {
        return PlayerPrefs.GetInt(progress, 0) == 0;
    }

    public static void Set(string progress, bool val)
    {
        PlayerPrefs.SetInt(progress, val ? 1 : 0);
    }
}
