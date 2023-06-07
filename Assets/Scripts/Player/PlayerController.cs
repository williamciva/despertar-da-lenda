using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // public Animator running;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    float input_x = 0;
    public float speed = 2.5f;
    public float jumpForce = 2.5f;
    bool isWalking = false;
    bool isComingBack = false;
    bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        isWalking = false;
        isComingBack = false;
        isJumping = false;
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        isJumping = Input.GetButtonDown("Jump") || Input.GetAxisRaw("Vertical") > 0;
        isWalking = (input_x != 0);
        isComingBack = (input_x < 0);

        if (isWalking)
        {
            rb.velocity =  new Vector2(input_x * speed, rb.velocity.y);
            // running.SetFloat("input_x", input_x);

            if ((isComingBack && !spriteRenderer.flipX) || (!isComingBack && spriteRenderer.flipX))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
            }
        }

        if (isJumping) { 
            rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }

        // running.SetBool("isWalkingForward", isWalkingForward);
        // running.SetBool("isWalkingBack", isWalkingBack);
        // running.SetBool("isJumping", isJumping);

        // if (Input.GetButtonDown("Fire1"))
        // {
        //     running.SetTrigger("attack");
        // }
    }
}
