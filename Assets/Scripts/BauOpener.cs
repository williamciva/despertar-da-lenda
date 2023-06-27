using UnityEngine;

public class BauOpener : MonoBehaviour
{

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl) || Input.GetKeyDown(KeyCode.RightControl))
        {
            AbrirBau();
        }
    }

    private void AbrirBau()
    {
        animator.SetTrigger("Abrir");
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().haveKey = true;
    }
}
