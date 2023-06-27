using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;

    private bool colliding;

    public float speed;

    public Transform rightCollider;
    public Transform leftCollider;
    public Transform headCollider;

    public LayerMask layer;

    public BoxCollider2D boxCollider2D;
    public CircleCollider2D circleCollider2D;

    bool playerDestroyed;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        rb.velocity = new Vector2(speed, rb.velocity.y);

        colliding = Physics2D.Linecast(rightCollider.position, leftCollider.position, layer);

        if (colliding)
        {
            transform.localScale = new Vector2(transform.localScale.x * -1f, transform.localScale.y);
            speed *= -1f;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            float height = collision.contacts[0].point.y - headCollider.position.y;

            if (height > 0 && !playerDestroyed)
            {
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * 10f, ForceMode2D.Impulse);
                speed = 0f;
                anim.SetTrigger("hit");
                boxCollider2D.enabled = false;
                circleCollider2D.enabled = false;
                rb.bodyType = RigidbodyType2D.Kinematic;

                Destroy(gameObject, 0.33f);
            }
            else
            {
                playerDestroyed = true;
                GameController.instance.ShowGameOver();
                Destroy(collision.gameObject);

            }
        }
    }
}
