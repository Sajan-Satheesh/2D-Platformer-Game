using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{
    public GameObject LevelCompScreen;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        string sceneName = SceneManager.GetActiveScene().name;
        Debug.Log("Level completed");
        LevelSingleton.levelInstance.SetLevelStatus(sceneName, LevelStatus.completed);
        if (sceneIndex < 5)
        {
            LevelSingleton.levelInstance.SetLevelStatus(SceneManager.GetSceneByBuildIndex(sceneIndex+1).name, LevelStatus.unlocked);
        }
        sceneIndex++;

        if (sceneIndex == 6)
        {
            sceneIndex = 1;
        }
        LevelManager.setCurrentLevel(sceneIndex);
        LevelCompScreen.SetActive(true);
    }
}