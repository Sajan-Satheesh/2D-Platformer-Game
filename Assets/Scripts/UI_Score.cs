using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_Score : MonoBehaviour
{
    public UI_text uiText;
    int score;
    int lives;

    // Start is called before the first frame update
    void Start()
    {
        lives = 3;
        score = 0;
    }
    public void updateScore()
    {
        score += 20;
        Debug.Log("Score is: " + score);
        uiText.scoreUI.text = "Score: " + score;
    }
}
