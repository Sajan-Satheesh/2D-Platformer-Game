
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ButtonClickCommands : MonoBehaviour
{
    public Button start;
    public Button quit;

    private void Awake()
    {
        start.onClick.AddListener(LoadNew);
        quit.onClick.AddListener(QuitGame);
    }
    void LoadNew()
    {
        SceneManager.LoadScene(1);
    }

    // Update is called once per frame


    private void QuitGame()
    {
        # if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
