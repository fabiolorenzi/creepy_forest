using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    public static bool isPlayerBlocked;

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
    private string DEATH_ANIMATION = "isDead";
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
        minPos = -8f;
        maxPos = 150f;
        score = 0;
        life = 3;
        isPlayerBlocked = false;
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

        if (life == 0 && sr.sprite.name == "Dude_Monster_Death_8_10")
        {
            Destroy(gameObject);
        }
    }

    void PlayerMovement()
    {
        movementX = Input.GetAxisRaw("Horizontal");

        if (transform.position.x > minPos && movementX < 0 && !isPlayerBlocked || transform.position.x < maxPos && movementX > 0 && !isPlayerBlocked)
        {
            transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
        }
    }

    void AnimatePlayer()
    {
        if (!isPlayerBlocked)
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
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if (!isPlayerBlocked) { 
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
        else
        {
            anim.SetBool(JUMP_ANIMATION, false);
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
            if (!anim.GetBool(HURT_ANIMATION) && life > 1)
            {
                playerHurt();
                life--;
                Life.UpdateLife(life);
            }
            else if (!anim.GetBool(HURT_ANIMATION) && life == 1)
            {
                FindObjectOfType<AudioManager>().PlaySound("player_death");
                playerDeath();
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
            life = 0;
            Life.UpdateLife(life);
            isPlayerBlocked = true;
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

    private void playerDeath()
    {
        anim.SetBool(DEATH_ANIMATION, true);
        isPlayerBlocked = true;
    }
}
