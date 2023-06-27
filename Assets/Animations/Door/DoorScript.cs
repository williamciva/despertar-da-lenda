using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    private Animator animator;

    // Start is called before the first frame update
    void Start() { 
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (GameObject.FindWithTag("Player").GetComponent<PlayerController>().haveKey) { 
                animator.SetTrigger("Open");
            }
        }
    }
}
