using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D rig;
    private Animator anim;

    public float speed, jumpForce;

    public bool isJumping, doubleJump;

    bool isBlowing;

    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
        Fall();
    }

    void Fall()
    {
        if (rig.velocity.y >= 0)
        {
            anim.SetBool("fall", false);
        }
        else
        {
            anim.SetBool("fall", true);
        }
    }
    void Move()
    {

        //move sem usar física
        //Vector3 movemant = new Vector3(Input.GetAxis("Horizontal"), 0F, 0F);
        //transform.position += movemant * Time.deltaTime * speed;

        float movemant = Input.GetAxis("Horizontal");
        rig.velocity = new Vector2(movemant * speed, rig.velocity.y);

        if (movemant > 0F)
        {
            anim.SetBool("walk", true);

            transform.eulerAngles = new Vector3(0F, 0F, 0F);
        }

        if (movemant < 0F)
        {
            anim.SetBool("walk", true);
            transform.eulerAngles = new Vector3(0F, 180F, 0F); //Rotacionar caso esteja olhando para esquerda AG20220203
        }

        if (Input.GetAxis("Horizontal") == 0F)
        {
            anim.SetBool("walk", false);
        }

    }

    void Jump()
    {
        if(Input.GetButtonDown("Jump") && !isBlowing)
        {
            if (!isJumping)
            {
                rig.AddForce(new Vector2(0F, jumpForce), ForceMode2D.Impulse);
                doubleJump = true;
                anim.SetBool("jump", true);
            }
            else
            {
                if (doubleJump)
                {
                    rig.AddForce(new Vector2(0F, jumpForce), ForceMode2D.Impulse);
                    anim.SetBool("doubleJump", true);
                    doubleJump = false;
                }
            } 
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer == 8)
        {
            isJumping = false;
            isBlowing = false;
            anim.SetBool("fall", false);
            anim.SetBool("jump", false);
            anim.SetBool("doubleJump", false);
        }

        if (collision.gameObject.tag == "Spike" || collision.gameObject.tag == "Saw") 
        {
            //CORRIGIR AG20220217
            anim.Play("Player_Hit");
            //StartCoroutine("hit");
            
            Destroy(gameObject, 6);

            GameController.instance.ShowGameOver();
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 8)
        {
            isJumping = true;
        }

    }

    //chama enquanto está colidindo
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 7)
        {
            isBlowing = true;
        }
    }
}
