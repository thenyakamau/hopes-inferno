using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private PlayerHealth playerHealth;
    [SerializeField] private Image totalHealthBar;
    [SerializeField] private Image currentHealthBar;

    // Start is called before the first frame update
    private void Start()
    {
        totalHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }

    // Update is c alled once per frame
    private void Update()
    {
        currentHealthBar.fillAmount = playerHealth.currentHealth / 10;
    }
}
