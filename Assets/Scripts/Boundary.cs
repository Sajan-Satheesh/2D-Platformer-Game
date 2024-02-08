
using UnityEngine;

public class Boundary : MonoBehaviour
{
    Enemy_script thisEnemy;
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy_script enemy))
        {
            enemy.scale.x *= -1f;
            thisEnemy = enemy;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out PlayerController player))
        {
            if (thisEnemy.scale.x/Mathf.Abs(thisEnemy.scale.x) == player.transform.localScale.x / Mathf.Abs(player.transform.localScale.x))
            {
                thisEnemy.scale.x *= -1f;
            }
        }
    }
}
