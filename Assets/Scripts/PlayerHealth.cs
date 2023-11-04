using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int initialHealth = 5;
    public int health;
    // Start is called before the first frame update
    void Start()
    {
        health = initialHealth;
    }

    public void DamageHealth(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
