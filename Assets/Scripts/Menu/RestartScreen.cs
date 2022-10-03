using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class RestartScreen : MonoBehaviour
{
    public Button restart;
    public Button mainmenu;
    // Start is called before the first frame update

    private void Awake()
    {
        gameObject.SetActive(false);
        restart.onClick.AddListener(Restart);
        mainmenu.onClick.AddListener(MainMenu);
    }
    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Appear()
    {
        gameObject.SetActive(true);
    }
    // Update is called once per frame


    private void MainMenu()
    {
        LevelManager.resume = true;
        LevelManager.setCurrentLevel(SceneManager.GetActiveScene().buildIndex);
        SceneManager.LoadScene(0);
    }
}