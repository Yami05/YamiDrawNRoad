using UnityEngine;


public enum ColorType
{
    Red,
    Blue,
}

public enum PoolItems
{
    ParkSpot,
    Crash,
    Coin,
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
