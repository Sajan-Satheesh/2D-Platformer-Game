
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerDead : MonoBehaviour
{
    public RestartScreen restartTrigger;
    /*private void Awake()
    {
        restartTrigger = GameObject.Find("RestartLevel").GetComponent<RestartScreen>();
    }*/
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            SoundManager.Instance.PlayGameSFX2(Sounds.Lose);
            DeadParticle.SimulateDeadParticle();
            restartTrigger.Appear();
        }
    }
}
