using UnityEngine;
using UnityEngine.UI;

public class ResetLevels : MonoBehaviour
{
    
    public Button reset;
    public GameObject levels;
    public GameObject[] ResettableImages;

    private void Awake()
    {
        reset.onClick.AddListener(Resort);
    }

    private void Resort()
    {
        Debug.Log("clicked Reset");
        LevelSingleton.levelInstance?.ResetData();
        ActivateButtons();
    }
    void ActivateButtons()
    {
        foreach(GameObject i in ResettableImages)
        {
            i.SetActive(true);
        }
    }
}
