using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelComplete : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        Debug.Log("Level completed");
        sceneIndex++;
        if (sceneIndex == 4)
        {
            sceneIndex = 1;
        }

        SceneManager.LoadScene(sceneIndex);
    }
}