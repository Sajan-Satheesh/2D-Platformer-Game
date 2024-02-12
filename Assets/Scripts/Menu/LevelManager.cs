public static class LevelManager
{
    public static int currentLevel = 1;
    public static bool resume = true;

    public static void SetCurrentLevel(int level)
    {
        currentLevel = level;
    }
    public static int GetCurrentLevel()
    {
        return currentLevel;
    }
}
