using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    float input_x = 0;
    public float speed = 2.5f;
    bool isWalking = false;

    // Start is called before the first frame update
    void Start()
    {
        isWalking = false;
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        isWalking = (input_x != 0);

        if (isWalking)
        {
            var move = new Vector3(input_x, 0, 0).normalized;
            transform.position += move * speed * Time.deltaTime;
            playerAnimator.SetFloat("input_x", input_x);
        }

        playerAnimator.SetBool("isWalking", isWalking);

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
}
