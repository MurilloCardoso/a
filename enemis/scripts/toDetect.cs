using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class detecte : MonoBehaviour
{
    public float dialogueRange;
    public LayerMask playerLayer;
    public GameObject player;
    public GameObject enemie;
    public float moveSpeed = 5f;
    private Collider2D lastHit;
    public status lifeStatus;
    public int lifeEnimie =100;

    private void FixedUpdate()
    {
        if (lifeEnimie<1)
        {
         
            Destroy(this.gameObject);
        }
        ShowDialogue();
        Attack();
    }
    private void Attack()
    {
        Vector2 boxSize = new Vector2(5f, 4f);
        Vector2 offset = new Vector2(1f, 1f);
        float angle = 0f;
        Collider2D hit = Physics2D.OverlapBox((Vector2)transform.position + offset, boxSize, angle, playerLayer);

        if (hit != null)
        {
            if (player != null && lifeStatus.LifeStatus >0)
            {
              
              lifeStatus.LifeStatus = lifeStatus.LifeStatus - 10;
            }
        }

        lastHit = hit;
    }
    private void ShowDialogue()
    {
        Vector2 boxSize = new Vector2(25f, 4f);
        Vector2 offset = new Vector2(1f, 1f);
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
    public void setHitDamage(int dano)
    {
        Debug.Log(lifeEnimie);
        lifeEnimie = lifeEnimie - dano;
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 boxSize = new Vector2(25f, 4f);
        Vector2 offset = new Vector2(1f,1f);

        Gizmos.color = lastHit != null ? Color.green : Color.red;
        Gizmos.DrawWireCube((Vector2)transform.position + offset, boxSize);
    }
}
