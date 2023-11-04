using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] private CapsuleCollider2D capsuleCollider;
    [SerializeField] private LayerMask playerLayer;

    [SerializeField] private float colliderDistance;
    [SerializeField] private float range;

    private EnemyAnimation enemyAnimation;

    private void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();
    }

    // Update is called once per frame
    private  void FixedUpdate()
    {
        if (PlayerInSight())
        {
            enemyAnimation.UpdateActionState();
        }
    }

    public bool PlayerInSight()
    {
        Bounds colliderBounds = capsuleCollider.bounds;
        Vector2 diffDist = colliderBounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector3 colliderSize = new Vector3(colliderBounds.size.x * range, colliderBounds.size.y, colliderBounds.size.z);

        RaycastHit2D rayCast = Physics2D.BoxCast(diffDist,colliderSize, 0, Vector2.left, 0, playerLayer);

        return rayCast.collider != null;
    }
     
    private void OnDrawGizmos()
    {
        Bounds colliderBounds = capsuleCollider.bounds;
        Vector2 diffDist = colliderBounds.center + transform.right * range * transform.localScale.x * colliderDistance;
        Vector3 colliderSize = new Vector3(colliderBounds.size.x * range, colliderBounds.size.y, colliderBounds.size.z);

        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(diffDist, colliderSize);
    }
}
