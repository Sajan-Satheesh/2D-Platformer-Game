using System;
using UnityEngine;

public class PlayerController : MonoBehaviour


{
    Rigidbody2D playerRb { get; set; }
    [SerializeField] private Animator animatorParameter;
    [SerializeField] private BoxCollider2D playerCollider;
    [SerializeField]private float speed;
    [SerializeField] private float stopDrag;
    private bool grounded = false;
    [SerializeField] private Vector2 jumpForce = new Vector2(0f, 500f);
    public int lives;
    public bool dead;
    public bool deadSound;
    public Vector2 velocity;
    /*DeadParticle deadParticle;*/
    
    //controls
    bool crouchingPress;
    bool crouchingRelease;
    float jumpButton;
    float movement;
    int jumpTimes;
    bool isJumping;
    bool walking;
    bool jumpable;

    //positional parameters
    Vector2 direction { get; set; }
    Vector2 scale;
    Vector2 size;
    Vector2 offset;

    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Start is called before the first frame update

    void Start()
    {
        jumpable = true;
        jumpTimes = 2;
        //playerRb.velocity = Vector2.zero;
        direction = Vector2.zero;
        SoundManager.Instance?.PlayGameSFX2(Sounds.LevelStart);
        dead = false;
        deadSound = false;
        lives = 3;
        playerCollider = gameObject.GetComponent<BoxCollider2D>();
        Debug.Log("Starting Player");
    }
    void Run(float key)
    {
        scale = transform.localScale;
        size = playerCollider.size;
        animatorParameter.SetFloat("speed", Mathf.Abs(key));
        if (Mathf.Abs(key) > 0)
        {
            walking = true;
            playerRb.drag = 0f;
            if (key < 0)
            {
                scale.x = -1f * Mathf.Abs(scale.x);
                direction = Vector2.left * speed;
            }
            else if (key > 0)
            {
                scale.x = Mathf.Abs(scale.x);
                direction = Vector2.right * speed;
            }
        }
        else if (walking)
        {
            walking = false;
            direction = Vector2.zero;
        }
        if (grounded && walking)
        {
            playerRb.velocity = direction;
            transform.localScale = scale;
        }
    }

    void Jump(float jumpKey)
    {
        if (jumpKey == 0) jumpable = true;
        if (jumpKey == 1 && jumpTimes > 0 && jumpable && playerRb.velocity.y < 0.1f)
        {
            isJumping = true;
            jumpable = false;
            grounded = false;
            SetDrag(0f);
            playerRb.AddForce(jumpForce, ForceMode2D.Impulse);
            jumpTimes--;
            animatorParameter.SetBool("jump", isJumping);
        }
    }

    private void SetDrag(float dragValue)
    {
        playerRb.drag = dragValue;
    }

    private void updateDrag()
    {
        if (grounded && !walking) SetDrag(stopDrag);
        else if(!grounded ) SetDrag(0f);
    }
    private void UpdateGrounded()
    {
        if (Mathf.Abs(playerRb.velocity.y) < 0.1f)
        {
            grounded = true;
        }
        else grounded = false;
    }

    void Crouch()
    {

        if (crouchingPress)
        {
            animatorParameter.SetBool("crouch", true);
            /*Debug.Log(size);*/
            playerCollider.offset = new Vector2(offset.x, 0.6f * offset.y);
            playerCollider.size = new Vector2(size.x, 0.6f * size.y);
            
        }
        else if (crouchingRelease)
        {
            animatorParameter.SetBool("crouch", false);
            /*Debug.Log(size);*/
            playerCollider.size = new Vector2(size.x, 2.1f);
            playerCollider.offset = new Vector2(offset.x, 0.98f);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (grounded)
        {
            if (isJumping)
            {
                jumpTimes = 2;
                isJumping = false;
                jumpable = true;
                animatorParameter.SetBool("jump", isJumping);
            }
        }
    }

    private void FixedUpdate()
    {
        if (walking && grounded)
        {
            SoundManager.Instance?.PlayPlayer(Sounds.PlayerRun);
        }
    }
   
    // Update is called once per frame
    public void Update()
    {
        velocity = playerRb.velocity;
        if (!dead)
        {
            UpdateGrounded();
            updateDrag();
            movement = Input.GetAxisRaw("Horizontal");
            jumpButton = Input.GetAxisRaw("Vertical");
            crouchingPress = Input.GetKeyDown(KeyCode.LeftControl);
            crouchingRelease = Input.GetKeyUp(KeyCode.LeftControl);
            Run(movement);
            Jump(jumpButton);
            Crouch();
        }
        else if(dead && !deadSound)
        {
            Debug.Log("death initiated");
            playerCollider.enabled = false;
            grounded = false;
            SetDrag(1f);
            playerRb.AddForce(jumpForce / 2, ForceMode2D.Impulse);
            animatorParameter.SetFloat("speed", 0);
            animatorParameter.SetBool("crouch", false);
            animatorParameter.SetBool("jump", false);
            animatorParameter.SetBool("dead", true);
            SoundManager.Instance?.PlayGameSfx(Sounds.PlayerDeath);
            SoundManager.Instance?.PlayGameSFX2(Sounds.Lose);
            deadSound = true;
            DeadParticle.SimulateDeadParticle();
        }
    }
}
