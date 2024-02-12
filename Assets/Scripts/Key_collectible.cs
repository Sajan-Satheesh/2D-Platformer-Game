using UnityEngine;

public class Key_collectible : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.gameObject.TryGetComponent(out UI_Score uI_Score))
        {
            Debug.Log("key collected");
            SoundManager.Instance?.PlayGameSFX2(Sounds.Collect);
            uI_Score.updateScore();
            Destroy(gameObject);
        }
    }
}