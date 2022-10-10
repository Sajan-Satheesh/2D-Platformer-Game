using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelCompScreen : MonoBehaviour
{
    [SerializeField] private Button Continue;
    [SerializeField] private Button Replay;

    private void Awake()
    {
        gameObject.SetActive(false);
        Continue.onClick.AddListener(ContinueGame);
        Replay.onClick.AddListener(ReplayGame);
    }

    private void ReplayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void ContinueGame()
    {
        SceneManager.LoadScene(LevelManager.getCurrentLevel());
    }

}
