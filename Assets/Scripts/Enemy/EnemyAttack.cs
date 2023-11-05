using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;

    [SerializeField] private Transform attackPoint;
    [SerializeField] LayerMask playerLayers;

    [SerializeField] float enemyDamage = 0.5f;

    [SerializeField] private float attackRange = 0.5f;

    [SerializeField] private float attackRate = 2f;
    private float nextAttackTime = 0f;

    public bool isAlive = true;

    // Start is called before the first frame update
    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frameß
    private void FixedUpdate()
    {
        if(enemyMovement.PlayerInSight() && isAlive)
        {
            if (Time.time >= nextAttackTime)
            {
                Attack();
                nextAttackTime = Time.time + 1f / attackRate;

                enemyMovement.UpdateActionState(EnemyMovement.MovementState.attack1);
            }
        }else
        {
            enemyMovement.UpdateActionState(EnemyMovement.MovementState.idle);
        }
    }

    private void Attack()
    {

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerLayers);

        foreach (Collider2D player in hitEnemies)
        {
            player.GetComponent<PlayerHealth>().TakeDamage(enemyDamage);
        }

    }

    private void OnDrawGizmos()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
