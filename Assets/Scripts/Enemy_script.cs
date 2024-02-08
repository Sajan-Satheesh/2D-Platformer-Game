
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    Vector2 position;
    public Vector2 scale;
    [SerializeField] private float speed=1;

    private void Start()
    {
        position = transform.position;
        scale = transform.localScale;
    }
    void Walk()
    {
        transform.localScale = scale;
        position = new Vector2(transform.position.x + speed *Time.deltaTime*scale.x, transform.position.y);
        transform.position = position;
        SoundManager.Instance?.PlayEnemy(Sounds.EnemeyWalk);
    }


    // Update is called once per frame
    void Update()
    {
        Walk();
    }
}
