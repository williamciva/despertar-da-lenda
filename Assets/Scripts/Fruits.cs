using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    private SpriteRenderer spriterenderer;
    private CircleCollider2D circleCollider;

    public GameObject collected;

    public int score;

    // Start is called before the first frame update
    void Start()
    {
        spriterenderer = GetComponent<SpriteRenderer>();
        circleCollider =  GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
       if( collider.gameObject.tag == "Player")
        {
            spriterenderer.enabled = false;
            circleCollider.enabled = false;
            collected.SetActive(true);

            GameController.instance.totalScore += score;
            GameController.instance.UpdateScoreText();

            Destroy(gameObject, 0.3f); //TEMPO PARA SER DESTRUIDO
        }  
    }
}
