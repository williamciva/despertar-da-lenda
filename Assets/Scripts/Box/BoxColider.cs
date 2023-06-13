using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxColider : MonoBehaviour
{
    public BoxCollider2D boundaryBox;

    private void OnTriggerEnter2D(Collider2D other)
    {
        // Verifica se o personagem entrou na "box"
        if (other.CompareTag("Player"))
        {
            // Mantém o personagem dentro dos limites da "box"
            Vector2 clampedPosition = other.transform.position;
            clampedPosition.x = Mathf.Clamp(
                clampedPosition.x,
                boundaryBox.bounds.min.x,
                boundaryBox.bounds.max.x
            );
            clampedPosition.y = Mathf.Clamp(
                clampedPosition.y,
                boundaryBox.bounds.min.y,
                boundaryBox.bounds.max.y
            );
            other.transform.position = clampedPosition;
        }
    }
}
