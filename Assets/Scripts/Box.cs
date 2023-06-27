using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Box : MonoBehaviour
{
    public float jumpForce;
    public bool isUp;

    public int heath = 5;
    public Animator anim;
    public GameObject effect;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BreakBox();   
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (isUp)
            {
                anim.SetTrigger("hit");
                heath--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0F, jumpForce), ForceMode2D.Impulse);
            }
            else
            {
                anim.SetTrigger("hit");
                heath--;
                collision.gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0F, -jumpForce), ForceMode2D.Impulse);
            }
        }
    }

    void BreakBox()
    {
        if (heath <= 0)
        {
            Instantiate(effect, transform.position, transform.rotation);
            Destroy(transform.parent.gameObject);
        }
    }
}
