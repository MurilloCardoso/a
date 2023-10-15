using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detecte : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public GameObject player;
    public float moveSpeed = 5f;
    private Collider2D lastHit;

    private void FixedUpdate()
    {
        ShowDialogue();
    }

    private void ShowDialogue()
    {
        Vector2 boxSize = new Vector2(25f, 4f);
        Vector2 offset = new Vector2(0f, 0f);
        float angle = 0f;
        Collider2D hit = Physics2D.OverlapBox((Vector2)transform.position + offset, boxSize, angle, playerLayer);
    
        if (hit != null)
        {
            if (player != null)
            {
                Vector3 direction = player.transform.position - transform.position;
                direction.Normalize();
                transform.Translate(direction * moveSpeed * Time.deltaTime);
            }
        }

        lastHit = hit;
    }

    private void OnDrawGizmosSelected()
    {
        Vector2 boxSize = new Vector2(25f,4f);
        Vector2 offset = new Vector2(0f, 0f);

        Gizmos.color = lastHit != null ? Color.green : Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + offset, boxSize);
    }
}
