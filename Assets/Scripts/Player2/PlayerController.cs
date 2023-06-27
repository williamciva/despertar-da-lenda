using UnityEngine;
using UnityEngine.Tilemaps;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D polygonCollider;
    public Rigidbody2D rb;
    public float jumpForce = 5f;
    float input_x = 0;
    public float speed = 2.5f;
    bool isMoving = false;
    bool isBackward = false;
    public bool haveKey = false;

    // Start is called before the first frame update
    void Start()
    {
        isMoving = false;
        isBackward = false;
        rb = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        polygonCollider = GetComponent<PolygonCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoviment();
        Jump();
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            if (Mathf.Abs(rb.velocity.y) < 0.01f)
            {
                rb.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
                playerAnimator.SetTrigger("jump");
            }
        }
    }

    private void PlayerMoviment()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        isMoving = input_x != 0;
        isBackward = input_x < 0;

        if (isMoving)
        {
            rb.velocity = new Vector2(input_x * speed, rb.velocity.y);

            if ((isBackward && !spriteRenderer.flipX) || (!isBackward && spriteRenderer.flipX))
            {
                spriteRenderer.flipX = !spriteRenderer.flipX;
                FlipCollider();
            }
        }

        playerAnimator.SetBool("isWalking", isMoving);
    }

    private void FlipCollider()
    {
        // Obtenha os pontos atuais do colisor
        Vector2[] points = polygonCollider.GetPath(0);

        // Inverta as coordenadas X dos pontos
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = new Vector2(-points[i].x, points[i].y);
        }

        // Defina os novos pontos invertidos no colisor
        polygonCollider.SetPath(0, points);
    }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     TilemapCollider2D plataform = GameObject
    //         .FindWithTag("Plataform")
    //         .GetComponent<TilemapCollider2D>();

    //     // Verifique a direção da colisão
    //     ContactPoint2D[] collisions = collision.contacts;

    //     foreach (var colision in collisions)
    //     {
    //         if (colision.collider == plataform)
    //         {
    //             if (colision.relativeVelocity.y > colision.relativeVelocity.x && rb.velocity.x != 0)
    //             {
    //                 rb.sharedMaterial.friction = 0;
    //                 break;
    //             }
    //             else if (colision.relativeVelocity.y < colision.relativeVelocity.x)
    //             {
    //                 rb.sharedMaterial.friction = 10;
    //             }
    //         }
    //     }
    // }
}
