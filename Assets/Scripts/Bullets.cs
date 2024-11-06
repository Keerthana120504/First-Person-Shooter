using UnityEngine;

public class Bullets : MonoBehaviour
{
    // Private


    // Public
    public float lifetime = 2f;
    public float damage = 30f;

    private void Awake()
    {
   
    }

    private void OnTriggerEnter(Collider other)
    {
        Enemy enemy = other.GetComponent<Enemy>();
        if (enemy != null)
        {
            enemy.TakeDamage(damage);
        }

        Destroy(gameObject); // Destroy the bullet on any trigger collision
    }

}
