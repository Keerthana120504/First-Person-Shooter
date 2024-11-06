using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Private
    PlayerHealth target;
    [SerializeField] float damage = 20f;

    // Public 
    public Transform attackPoint;
    public float attackRange = 10f;
    public LayerMask playerLayer;
    
    
    // Start is called before the first frame update
    void Start()
    {
        target = FindAnyObjectByType<PlayerHealth>();
    }

    
    public void AttackHitEvent()
    {
        if (target == null) return;

        Collider[] hitplayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitplayer)
        {
            Debug.Log("Attacked the " + player.name);
            target.TakeDamage(damage);
        }

    }

    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
        
    }
}
