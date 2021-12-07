using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditScript : MonoBehaviour
{
    public Animator animator;
    public int MaxHealth = 100;
    int currentHealth;

    public Transform player;
    public float agroRange;
    public float moveSpeed;
    Rigidbody2D rb2D;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = MaxHealth;

        rb2D = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer <= agroRange)
        {
            
            if (transform.position.x < player.position.x)
            {
                rb2D.velocity = new Vector2(moveSpeed, 0);
                //transform.localScale = new Vector2(1, 1);
            }
            else
            {
                rb2D.velocity = new Vector2(-moveSpeed, 0);
                //transform.localScale = new Vector2(-1, 1);
            }
            animator.SetInteger("AnimState", 2);
        }
        else
        {
            rb2D.velocity = Vector2.zero;
            animator.SetInteger("AnimState", 0);
        }

        
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            GetComponent<Collider2D>().enabled = false;
            this.enabled = false;
            animator.SetTrigger("Hurt");
            animator.SetTrigger("Death");

        }

    }
}
