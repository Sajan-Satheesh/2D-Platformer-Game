using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_life : MonoBehaviour
{
    public GameObject[] lives;

    public void ReduceHealthUI(int life)
    {
        lives[life].SetActive(false);
    }
}
