using UnityEngine;
using UnityEngine.SceneManagement;



public class EnemyAttack : MonoBehaviour
{
    [SerializeField] private float attackingTimeInterval = 2f;   
    private float targetTime;
    private float currentTime;
    UI_life life;
    public RestartScreen restartScreen;

    private void Awake()
    {
        life = GameObject.Find("Canvas/Health").GetComponent<UI_life>();
    }
    private void Attack(PlayerController player)
    {
        SoundManager.Instance?.PlaySfx(Sounds.EnemeyAttack);
        player.lives--;
        if (player.lives > -1)
        {
            life.ReduceHealthUI(player.lives);
        }
        targetTime = currentTime + attackingTimeInterval;
        Debug.Log("Lives is : " + player.lives);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            targetTime = 0f;
            currentTime = Time.time;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            currentTime = Time.time;
            if (currentTime > targetTime)
            {
                Attack(player);
            }
            if (player.lives <= 0)
            {
                player.dead = true;
                restartScreen.Appear();
            }
        }
    }
}
