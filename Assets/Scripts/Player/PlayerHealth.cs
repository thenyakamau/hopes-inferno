using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static PlayerMovement;

public class PlayerHealth : MonoBehaviour
{
    [SerializeField] private float startingHealth;
    public float currentHealth { get; private set; }

    private PlayerMovement playerMovement;
    private bool isDead = false;

    private void Awake()
    {
        currentHealth = startingHealth;
    }

    private void Start()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Trap")
        {
            TakeDamage(0.5f);
        }
    }

    public void TakeDamage(float _damage)
    {
        if (Input.GetButton("Fire2"))
            return;

        currentHealth = Mathf.Clamp(currentHealth - _damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            playerMovement.UpdateDamageAnimation(PlayerMovement.MovementState.hurt);
        }
        else
        {
            Debug.Log("Dead player here");
            if (!isDead)
            {
                playerMovement.UpdateDamageAnimation(PlayerMovement.MovementState.death);

            }

        }
    }
}
