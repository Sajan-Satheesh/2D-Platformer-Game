using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum LevelStatus
{
    locked, unlocked, completed
}
public static class LevelManager
{
    public static int currentLevel;
    public static bool resume = false;

    public static void setCurrentLevel(int level)
    {
        currentLevel = level;
    }
    public static int getCurrentLevel()
    {
        return currentLevel;
    }
}
