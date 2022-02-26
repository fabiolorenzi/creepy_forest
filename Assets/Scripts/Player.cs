using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 10f;
    private float movementX;

    [SerializeField]
    private Rigidbody2D playerBody;
    private Animator anim;
    private SpriteRenderer sr;
    private string WALK_ANIMATION = "isWalking";
    private string JUMP_ANIMATION = "isJumping";
    private string HURT_ANIMATION = "isHurt";
    private string GROUND = "Ground";
    private string VOID = "Void";

    private bool isGrounded;
    private bool isDoubleJumped;

    [SerializeField]
    private float minPos, maxPos;

    public static int score;
    public static int life;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
        score = 0;
        life = 3;
    }

    void Start()
    {
        Score.UpdateScore(score);
        Life.UpdateLife(life);
    }

    void Update()
    {
        PlayerMovement();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        minPos = -8f;

        if (transform.position.x > minPos && movementX < 0 || movementX > 0)
        {
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        }
    }

    void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            isGrounded = false;
            playerBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
            FindObjectOfType<AudioManager>().PlaySound("jump");
        }
        else if (Input.GetButtonDown("Jump") && !isGrounded && !isDoubleJumped)
        {
            isDoubleJumped = true;
            playerBody.AddForce(new Vector2(0f, jumpForce * 1.3f), ForceMode2D.Impulse);
            anim.SetBool(JUMP_ANIMATION, true);
            FindObjectOfType<AudioManager>().PlaySound("jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND))
        {
            isGrounded = true;
            isDoubleJumped = false;
            anim.SetBool(JUMP_ANIMATION, false);
        }

        if (collision.gameObject.CompareTag("Coin"))
        {
            score++;
            Score.UpdateScore(score);
            FindObjectOfType<AudioManager>().PlaySound("coinCatch");
        }

        if (collision.gameObject.CompareTag("Spikes"))
        {
            if (!anim.GetBool(HURT_ANIMATION))
            {
                playerHurt();
                life--;
                Life.UpdateLife(life);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(VOID))
        {
            FindObjectOfType<AudioManager>().PlaySound("player_fall");
        }
    }

    private void playerHurt()
    {
        FindObjectOfType<AudioManager>().PlaySound("player_hurt");
        anim.SetBool(HURT_ANIMATION, true);
        StartCoroutine(playerHurtAnim());
    }

    IEnumerator playerHurtAnim()
    {
        yield return new WaitForSeconds(2);

        anim.SetBool(HURT_ANIMATION, false);
    }
}
