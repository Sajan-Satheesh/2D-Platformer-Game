using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class LevelManager
{
    public static string Level1 = "Level1";
    public static string Level2 = "Level2";
    public static string Level3 = "Level3";
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
