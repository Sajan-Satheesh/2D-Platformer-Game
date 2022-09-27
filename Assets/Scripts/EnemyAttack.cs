using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyAttack : MonoBehaviour
{
    public float TnextReduction = 2f;   
    private float Tcurrent;
    private float Trunning;
    UI_life life; 

    private void Awake()
    {
        life = GameObject.Find("Canvas/Health").GetComponent<UI_life>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Tcurrent = 0f;
        Trunning = Time.time;
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            player.lives--;
            if (player.lives > -1)
            {
                life.HealthUI(player.lives);
            }
            Tcurrent = Trunning + TnextReduction;
            Debug.Log("Lives is : " + player.lives);
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            Trunning = Time.time;
            if (Trunning > Tcurrent)
            {
                Tcurrent = Trunning + TnextReduction;
                player.lives--;
                if (player.lives > -1)
                {
                    life.HealthUI(player.lives);
                }
                Debug.Log("Lives is : " + player.lives);
            }
            if (player.lives <= 0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
        }
    }
}
