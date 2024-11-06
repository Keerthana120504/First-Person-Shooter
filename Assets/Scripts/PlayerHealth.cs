using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Private
    [SerializeField] float health = 100f;

    // public
    public Slider healthBar;

    private void Start()
    {
        healthBar.value = health;   
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            GetComponent<DeathHandler>().HandleDeath();
        }
        healthBar.value = health;
    }
}
