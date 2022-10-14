using System;
using UnityEngine;

public class PlayerController : MonoBehaviour


{
    Rigidbody2D playerRb;
    [SerializeField] private Animator animatorParameter;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField]private float displace;
    private bool collisionDetected = false;
    [SerializeField] private Vector2 force = new Vector2(0f, 500f);
    public int lives;
    public bool dead;
    public bool deadSound;
    
    //controls
    bool pressCtrl;
    bool releaseCtrl;
    float upButton;
    float movement;
    bool jump;
    bool walking;

    //positional parameters
    Vector2 position;
    Vector2 scale;
    Vector2 size;
    Vector2 offset;



    // Start is called before the first frame update
    void Start()
    {
        dead = false;
        deadSound = false;
        lives = 3;
        displace = 5.0f;
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        playerRb = gameObject.GetComponent<Rigidbody2D>();
        Debug.Log("Starting Player");
    }
    void Run(float key)
    {
        walking = false;
        position = transform.localPosition;
        scale = transform.localScale;
        size = playerCollider.size;
        offset = playerCollider.offset;

        animatorParameter.SetFloat("speed", Mathf.Abs(key));
        if (key != 0)
        {
            walking = true;
        }
        if (key < 0)
        {
            scale.x = -1f * Mathf.Abs(scale.x);
            position.x += key * displace * Time.deltaTime;
        }
        else if (key > 0)
        {
            scale.x = Mathf.Abs(scale.x);
            position.x += key * displace * Time.deltaTime;
        }
        transform.position = position;
        transform.localScale = scale;
    }
    void Jump(float key)
    {
        jump = false;
        if (collisionDetected)
        {
            if (key > 0)
            {
                jump = true;
                playerRb.AddForce(force, ForceMode2D.Impulse);
                collisionDetected = false;
            }
            animatorParameter.SetBool("jump", jump);
        }

    }
    void Crouch()
    {

        if (pressCtrl)
        {
            animatorParameter.SetBool("crouch", true);
            /*Debug.Log(size);*/
            playerCollider.size = new Vector2(size.x, 0.6f * size.y);
            playerCollider.offset = new Vector2(offset.x, 0.6f * offset.y);
        }
        else if (releaseCtrl)
        {
            animatorParameter.SetBool("crouch", false);
            /*Debug.Log(size);*/
            playerCollider.size = new Vector2(size.x, 2.1f);
            playerCollider.offset = new Vector2(offset.x, 0.98f);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collisionDetected = true;
    }

    private void FixedUpdate()
    {
        if (walking && collisionDetected)
        {
            SoundManager.Instance.PlayPlayer(Sounds.PlayerRun);
        }
    }
   
    // Update is called once per frame
    public void Update()
    {
        //understand dif betw
        //
        //
        //
        //een GetAxis and GetAxisRaw
        if (!dead)
        {
            movement = Input.GetAxisRaw("Horizontal");
            upButton = Input.GetAxisRaw("Vertical");
            pressCtrl = Input.GetKeyDown(KeyCode.LeftControl);
            releaseCtrl = Input.GetKeyUp(KeyCode.LeftControl);

            Run(movement);
            Jump(upButton);
            Crouch();
        }
        else if(dead && !deadSound)
        {
            SoundManager.Instance.PlayGameSfx(Sounds.PlayerDeath);
            deadSound = true;
        }
    }
}
