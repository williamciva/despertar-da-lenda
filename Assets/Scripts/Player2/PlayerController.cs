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

    // private void OnColliderInPlataform()
    // {
    //     // Configurar parâmetros do Raycast
    //     Vector2 raycastOrigin = rb.position; // posição do personagem
    //     float raycastDistance = 5f; // distância do raio
    //     Vector2 raycastDirection = Vector2.down; // direção do raio (para baixo)
    //     TilemapCollider2D tilemapCollider2D = GameObject
    //         .FindWithTag("Plataform")
    //         .GetComponent<TilemapCollider2D>();

    //     // Realizar o Raycast
    //     RaycastHit2D hit = Physics2D.Raycast(raycastOrigin, raycastDirection, raycastDistance);

    //     // Verificar se ocorreu colisão com a parte superior da plataforma
    //     if (hit.collider != null && hit.collider.CompareTag("Plataform") )
    //     {
    //         Physics2D.IgnoreCollision(polygonCollider, tilemapCollider2D, false);
    //         return;
    //     }

    //     Physics2D.IgnoreCollision(polygonCollider, tilemapCollider2D, true);
    // }

    // private void OnCollisionEnter2D(Collision2D collision)
    // {
    //     TilemapCollider2D tilemapCollider2D = GameObject
    //         .FindWithTag("Plataform")
    //         .GetComponent<TilemapCollider2D>();

    //     // Verifique a direção da colisão
    //     ContactPoint2D[] collisions = collision.contacts;

    //     foreach (var colision in collisions)
    //     {
    //         if (colision.collider == tilemapCollider2D)
    //         {
    //             if (colision.collider.bounds.max.y > rb.position.y && rb.velocity.y >= 0)
    //             {
    //                 // Ignore temporariamente a colisão com a plataforma
    //                 Physics2D.IgnoreCollision(polygonCollider, collision.collider, false);
    //                 break;
    //             }
    //             Physics2D.IgnoreCollision(polygonCollider, collision.collider, true);
    //             rb.AddForce(new Vector2(0f, rb.velocity.y), ForceMode2D.Impulse);
    //         }

    //         if (
    //             colision.collider
    //             == GameObject.FindWithTag("Ground").GetComponent<TilemapCollider2D>()
    //         )
    //         {
    //             Physics2D.IgnoreCollision(polygonCollider, tilemapCollider2D, false);
    //             break;
    //         }
    //     }
    // }
}
