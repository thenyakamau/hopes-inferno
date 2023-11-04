using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    private EnemyMovement enemyMovement;


    // Start is called before the first frame update
    private void Start()
    {
        enemyMovement = GetComponent<EnemyMovement>();
    }

    // Update is called once per frameß
    private void Update()
    {
        
    }

    private void DamagePlayer()
    {
        if (enemyMovement.PlayerInSight())
        {
            Debug.Log("Attack the player here");
        }
    }
}
