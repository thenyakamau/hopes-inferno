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

    public enum MovementState { idle, running, attack1, attack2 }


    private SpriteRenderer spriteRenderer;
    private Animator animator;

    private void Start()
    {
        enemyAnimation = GetComponent<EnemyAnimation>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    //private  void FixedUpdate()
    //{
    //    if (PlayerInSight())
    //    {
    //        UpdateActionState();
    //    }else
    //    {
    //        MovementState state = MovementState.idle;

    //        int stateValue = (int)state;
    //        animator.SetInteger("state", stateValue);

    //    }
    //}

    public void UpdateActionState(MovementState currentState)
    {
       
        int stateValue = (int)currentState;
        animator.SetInteger("state", stateValue);

    }

    public void UpdateAnimationState()
    {
        // Else statement is not required here because initial state is set
        float directionX = Input.GetAxisRaw("Horizontal");
        MovementState state = MovementState.idle;

        if (directionX > 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = false;
        }
        else if (directionX < 0f)
        {
            state = MovementState.running;
            spriteRenderer.flipX = true;
        }

        int stateValue = (int)state;
        animator.SetInteger("state", stateValue);
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
