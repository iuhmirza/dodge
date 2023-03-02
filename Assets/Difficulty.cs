using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Difficulty
{
    static float secondsToMaxDifficulty = 1080;

    public static float GetDifficultyPercent()
    {
        return Mathf.Clamp01(Time.time / secondsToMaxDifficulty);
    }
}
