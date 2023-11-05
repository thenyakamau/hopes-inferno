using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    [SerializeField] private float maxHealth = 100;
    private float currentHealth;
    private Animator animator;
    private Collider2D enemyCollider;

    private void Awake()
    {
        currentHealth = maxHealth;
        animator = GetComponent<Animator>();
        enemyCollider = GetComponent<CapsuleCollider2D>();
    }


    // Update is called once per frame
    private void Update()
    {
        
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        animator.SetInteger("state", 4);

        if (currentHealth <=0)
        {
            Die();
        } 
    }

    private void Die()
    {
        
        GetComponent<EnemyAttack>().enabled = false;
        animator.SetInteger("state", 5);
        
        this.enabled = false;

        Invoke("RemoveEnemy", 2f);
    }

    private void RemoveEnemy()
    {
        Destroy(gameObject);
    }
}
