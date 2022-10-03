using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_life : MonoBehaviour
{
    public GameObject[] lives = new GameObject[3];

    public void ReduceHealth(int life)
    {
        lives[life].SetActive(false);
    }
}
