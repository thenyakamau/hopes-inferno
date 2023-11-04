using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimation : MonoBehaviour
{

    private enum MovementState { idle, running, attack1, attack2 }

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    [SerializeField] private bool enemyHasSecondAttack = false;
    int currentAttack = 0;

    // Start is called before the first frame update
    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    private void Update()
    {
        
    }

    public void UpdateActionState()
    {
        MovementState state = MovementState.attack1;
        //if (enemyHasSecondAttack)
        //{
        //    if (currentAttack == 0)
        //    {
        //        state = MovementState.attack1;
        //        currentAttack = 1;
        //    }else
        //    {
        //        state = MovementState.attack2;
        //        currentAttack = 0;
        //    }
        //}

        int stateValue = (int)state;
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
}
