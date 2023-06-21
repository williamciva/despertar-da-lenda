using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    float input_x = 0;
    public float speed = 2.5f;
    bool isMoving = false;
    bool isBackward = false;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        isBackward = false;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoviment();

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }

    void Jump()
    {
        if (Mathf.Abs(rb.velocity.y) < 0.01f)
        {
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
            playerAnimator.SetTrigger("jump");
        }
    }

    void PlayerMoviment()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        isMoving = input_x != 0;
        isBackward = (input_x < 0);

        if (isMoving)
        {
            rb.velocity = new Vector2(input_x * speed, rb.velocity.y);

            if ((isBackward && !spriteRenderer.flipX) || (!isBackward && spriteRenderer.flipX))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }

        }

        playerAnimator.SetBool("isWalking", isMoving);
    }
}
