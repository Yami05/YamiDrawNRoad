using UnityEngine;


public enum ColorType
{
    Red,
    Blue,
    yellow,
}

public enum PoolItems
{
    ParkSpot,
    Crash,
    Coin,
    Trail,
}

public enum AnimType
{

}

public class Utilities : MonoBehaviour
{
    public const string LevelIndex = "LevelIndex";

    public static void SetLevelPref(int levelCount = 1)
    {
        PlayerPrefs.SetInt(LevelIndex, PlayerPrefs.GetInt(LevelIndex, 0) + levelCount);
    }
}
