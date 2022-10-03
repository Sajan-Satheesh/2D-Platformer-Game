using UnityEngine;
using UnityEngine.SceneManagement;



public class EnemyAttack : MonoBehaviour
{
    [SerializeField]private float TnextReduction = 2f;   
    private float Tcurrent;
    private float Trunning;
    UI_life life;
    public RestartScreen restartTrigger;

    private void Awake()
    {
        life = GameObject.Find("Canvas/Health").GetComponent<UI_life>();
    }
    private void Attack(PlayerController player)
    {
        player.lives--;
        if (player.lives > -1)
        {
            life.HealthUI(player.lives);
        }
        Tcurrent = Trunning + TnextReduction;
        Debug.Log("Lives is : " + player.lives);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tcurrent = 0f;
        Trunning = Time.time;
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Attack(player);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Trunning = Time.time;
            if (Trunning > Tcurrent)
            {
                Attack(player);
            }
            if (player.lives <= 0)
            {
                player.dead = true;
                restartTrigger.Appear();
            }
        }
    }
}
