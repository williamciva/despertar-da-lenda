using UnityEngine;
using UnityEngine.Tilemaps;

public class PlataformScript : MonoBehaviour
{
    private Rigidbody2D rb;
    private TilemapCollider2D tilemapCollider2D;

    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tilemapCollider2D = GetComponent<TilemapCollider2D>();
    }

    // Update is called once per frame
    private void Update() { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifique a direção da colisão
        Vector2 collisionNormal = collision.contacts[0].normal;

        // Verifique se a colisão ocorreu na lateral da plataforma (direção horizontal)
        if (Mathf.Abs(collisionNormal.x) > Mathf.Abs(collisionNormal.y))
        {
            // Ignore temporariamente a colisão com a plataforma
            Physics2D.IgnoreCollision(tilemapCollider2D, collision.collider, true);
        }
    }
}
