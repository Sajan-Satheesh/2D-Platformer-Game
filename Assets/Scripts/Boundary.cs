
using UnityEngine;

public class Boundary : MonoBehaviour
{
    public void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.TryGetComponent(out Enemy_script enemy))
        {
            enemy.scale.x *= -1f;
            /*enemy.speed *= -1;*/
        }
    }
}
