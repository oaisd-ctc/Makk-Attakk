using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    // Serialized fields
    public static float runSpeed = 8f;
    [SerializeField] float jumpSpeed = 5f;
    [SerializeField]
    float climbSpeed = 5f;


    //    [SerializeField] Vector2 deathKick = new Vector2(10f, 10f);
    //    [SerializeField] GameObject bullet;
    //    [SerializeField] Transform gun;

    //Variables
    public AudioClip deathSound;
    private AudioSource audioSource;
    Vector2 moveInput;
    Rigidbody2D myRigidbody;
    Animator myAnimator;
    CapsuleCollider2D myBodyCollider;
    GameSession gameSession;

    float gravityScaleAtStart;

    public LayerMask interactableLayer;
    public GameObject text;

    private GameObject player;
    private Vector3 scaleChange;


    bool isAlive = true;

    // Assigning variables to the objects



    private void Awake()
    {
        scaleChange = new Vector2(-.1122f, .1122f);
    }

    void Start()
    {
        player = GetComponent<GameObject>();
        myRigidbody = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
        myBodyCollider = GetComponent<CapsuleCollider2D>();
        gravityScaleAtStart = myRigidbody.gravityScale;
        gameSession = GetComponent<GameSession>();
        //Debug.Log(PlayerMovement.runSpeed);

    }

    void Update()
    {
        if (!isAlive) { return; }
        Run();
        Jump();

        float horizontalInput = Input.GetAxis("Horizontal");
        if (horizontalInput > 0)
        {
            FlipSprite(1f);
        }
        else if (horizontalInput < 0)
        {
            FlipSprite(-1f);
        }

        ClimbLadder();
        Die();

    }


    void OnMove(InputValue value)
    {
        if (!isAlive) { return; }
        moveInput = value.Get<Vector2>();
    }



    void OnJump(InputValue value)
    {
        if (!isAlive) { return; }
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Ground"))) { return; }

        if (value.isPressed)
        {
            myRigidbody.velocity += new Vector2(0f, jumpSpeed);

        }
    }

    void Run()
    {
        Vector2 playerVelocity = new(moveInput.x * runSpeed, myRigidbody.velocity.y);
        myRigidbody.velocity = playerVelocity;

        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;
        myAnimator.SetBool("isRunning", playerHasHorizontalSpeed);
    }



    void FlipSprite(float direction)
    {
        bool playerHasHorizontalSpeed = Mathf.Abs(myRigidbody.velocity.x) > Mathf.Epsilon;

        if (playerHasHorizontalSpeed)
        {
            Vector3 currentScale = transform.localScale;
            currentScale.x = Mathf.Abs(currentScale.x) * direction;
            transform.localScale = currentScale;

            //Debug.Log(transform.localScale.x);
        }
    }

    void ClimbLadder()
    {
        if (!myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Climbing")))
        {
            myRigidbody.gravityScale = gravityScaleAtStart;
            myAnimator.SetBool("isClimbing", false);
            return;
        }

        Vector2 climbVelocity = new Vector2(myRigidbody.velocity.x, moveInput.y * climbSpeed);
        myRigidbody.velocity = climbVelocity;
        myRigidbody.gravityScale = 0f;

        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isClimbing", playerHasVerticalSpeed);
    }

    void Jump()
    {
        bool playerHasVerticalSpeed = Mathf.Abs(myRigidbody.velocity.y) > Mathf.Epsilon;
        myAnimator.SetBool("isJumping", playerHasVerticalSpeed);
    }

    void Die()
    {

        if (myBodyCollider.IsTouchingLayers(LayerMask.GetMask("Enemies", "Hazards")))
        {
            isAlive = false;
            //            myAnimator.SetTrigger("Dying");
            //           myRigidbody.velocity = deathKick;

            //FindObjectOfType<GameSession>().ProcessPlayerDeath();
            Reset();
        }
    }

    public void Reset()
    {
        FindObjectOfType<GameSession>().playerLives = 0;
        runSpeed = 8f;
        jumpSpeed = 15f;
        climbSpeed = 5f;
    }
}
