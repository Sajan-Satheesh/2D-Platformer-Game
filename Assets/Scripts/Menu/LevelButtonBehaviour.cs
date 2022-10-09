using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class LevelButtonBehaviour : MonoBehaviour
{
    private Button button;
    public string LevelName;

    private void Awake()
    {
        button = GetComponent<Button>();
        button.onClick.AddListener(onClick);
    }

    private void onClick()
    {
        LevelStatus levelStatus = LevelSingleton.levelInstance.GetLevelStatus(LevelName);
        switch(levelStatus){
            case LevelStatus.locked:
                Debug.Log("Level "+ LevelName + " is locked");
                break;
            case LevelStatus.unlocked:
                SceneManager.LoadScene(LevelName);
                break;
            case LevelStatus.completed:
                SceneManager.LoadScene(LevelName);
                break;
        }
    }
}
