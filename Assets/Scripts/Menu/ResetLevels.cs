using UnityEngine;
using UnityEngine.UI;

public class ResetLevels : MonoBehaviour
{
    public Button reset;
    public GameObject levels;
    private void Awake()
    {
        reset.onClick.AddListener(Resort);
    }

    private void Resort()
    {
        Debug.Log("clicked Reset");
        LevelSingleton.levelInstance.ResetData();
    }
}
