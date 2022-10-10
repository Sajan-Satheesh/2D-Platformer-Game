using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSingleton : MonoBehaviour
{
    private static LevelSingleton levelinstance;
    public static LevelSingleton levelInstance { get { return levelinstance; }}

    private void Awake()
    {
        if(levelinstance == null)
        {
            levelinstance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public LevelStatus GetLevelStatus(string level)
    {
        LevelStatus levelStatus = (LevelStatus)PlayerPrefs.GetInt(level);
        return levelStatus;
    }

    public void SetLevelStatus(string level, LevelStatus levelStatus)
    {
        PlayerPrefs.SetInt(level, (int)levelStatus);
    }

    public void ResetData()
    {
        Debug.Log("resetting data");
        string level = "";
        for (int i = 2; i < 4; i++)
        {
            level += i;
            PlayerPrefs.SetInt(level, (int)LevelStatus.locked);
            Debug.Log("Level "+level+ " locked");
            level = "";
        }
    }

}
