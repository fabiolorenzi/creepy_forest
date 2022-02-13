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
    private string WALK_ANIMATION = "Walk";
    private string GROUND = "Ground";

    private bool isGrounded;
    private bool isDoubleJumped;

    [SerializeField]
    private float minPos, maxPos;

    private void Awake()
    {
        playerBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        PlayerMovement();
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
}
