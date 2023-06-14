using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public Animator running;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidiBody;
    float input_x = 0;
    public float speed = 2.5f;
    public float jumpForce = 2.5f;
    bool isMoving = false;
    bool isBackward = false;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rigidiBody = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isMoving = false;
        isBackward = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoviment();
        Jump();

        // running.SetBool("isWalkingForward", isWalkingForward);
        // running.SetBool("isWalkingBack", isWalkingBack);
        // running.SetBool("isJumping", isJumping);

        // if (Input.GetButtonDown("Fire1"))
        // {
        //     running.SetTrigger("attack");
        // }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            isJumping = false;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Plataform"))
        {
            isJumping = true;
        }
    }

    void Jump()
    {
        bool touchJump = Input.GetButtonDown("Jump")| Input.GetButton("Jump");

        if (!isJumping && touchJump)
        {
            rigidiBody.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    void PlayerMoviment()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        isMoving = input_x != 0;
        isBackward = (input_x < 0);
        
        if (isMoving)
        {
            rigidiBody.velocity = new Vector2(input_x * speed, rigidiBody.velocity.y);

            if ((isBackward && !spriteRenderer.flipX) || (!isBackward && spriteRenderer.flipX))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }
    }
}
