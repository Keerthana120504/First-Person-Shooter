
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    // Private
    AudioManager audioManager;
    [SerializeField] float health = 100f;


    // public
    public Slider healthBar;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        healthBar.value = health;   
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        if (health <= 0)
        {
            audioManager.PlaySFX(audioManager.death);
            GetComponent<DeathHandler>().HandleDeath();
        }
        healthBar.value = health;
    }
}
