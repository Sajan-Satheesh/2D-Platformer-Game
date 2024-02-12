
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class ButtonClickCommands : MonoBehaviour
{
    [SerializeField] private Button play;
    [SerializeField] private Button start;
    [SerializeField] private Button quit;
    [SerializeField] private Button back;

    [SerializeField] private GameObject LevelPanel;

    private void Awake()
    {
        LevelPanel.SetActive(false);
        play.onClick.AddListener(LoadNew);
        start.onClick.AddListener(LevelSelection);
        quit.onClick.AddListener(QuitGame);
        back.onClick.AddListener(LevelSelection);
    }

    private void LevelSelection()
    {
        
        if (LevelPanel.activeSelf)
        {
            LevelPanel.SetActive(false);
        }
        else LevelPanel.SetActive(true);
        SoundManager.Instance?.PlaySfx(Sounds.Click);
    }

    void LoadNew()
    {
       
        if (LevelManager.resume == true)
        {
            SceneManager.LoadScene(LevelManager.GetCurrentLevel());
        }
        else SceneManager.LoadScene(1);
        SoundManager.Instance?.PlaySfx(Sounds.Click);
    }



    // Update is called once per frame


    private void QuitGame()
    {
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
        Application.Quit();
    }
}
