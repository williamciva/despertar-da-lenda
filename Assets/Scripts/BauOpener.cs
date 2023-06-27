using UnityEngine;

public class BauOpener : MonoBehaviour
{

    private Animator animator;
    private AudioSource audioSource;

    private void Start()
    {
        animator = GetComponent<Animator>();
        audioSource = GetComponent<AudioSource>();
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
        audioSource.Play();
        GameObject.FindWithTag("Player").GetComponent<PlayerController>().haveKey = true;
    }
}
