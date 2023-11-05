using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombant : MonoBehaviour
{
    [SerializeField] private Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;

    [SerializeField] private float attackDamage = 40f;
    [SerializeField] private float attackRange = 0.5f;

    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    // Update is called once per frame
    private void Update()
    {
        if (Time.time >= nextAttackTime)
            if (Input.GetButtonDown("Fire1"))
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;
            }
    }

    private void Attack()
    {
       
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<EnemyHealth>().TakeDamage(attackDamage);
        }

    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
