using UnityEngine;

public class BauOpener : MonoBehaviour
{
    public GameObject bau;
    public AnimationClip animacaoBau;

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
        animator.Play(animacaoBau.name);
    }
}
