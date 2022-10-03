
using UnityEngine;

public class Enemy_script : MonoBehaviour
{
    Vector2 position;
    public Vector2 scale;
    public float speed=1;

    private void Start()
    {
        position = transform.position;
        scale = transform.localScale;
    }
    void Walk()
    {
        position = new Vector2(transform.position.x + speed *Time.deltaTime*scale.x, transform.position.y);
        transform.position = position;
    }


    // Update is called once per frame
    void Update()
    {
        transform.localScale = scale;
        Walk();
    }
}
