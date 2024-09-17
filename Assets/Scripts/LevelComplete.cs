using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        SoundManager.Instance?.PlayGameSFX2(Sounds.Win);
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Level completed");
        LevelSingleton.levelInstance?.SetLevelStatus(sceneName, LevelStatus.completed);
        if (sceneIndex < 5)
        {
            LevelSingleton.levelInstance?.SetLevelStatus((sceneIndex+1).ToString(), LevelStatus.unlocked);
        }
        sceneIndex++;

        if (sceneIndex == 6)
        {
            sceneIndex = 1;
        }
        LevelManager.SetCurrentLevel(sceneIndex);
        
        LevelCompScreen.SetActive(true);
        
    }
}