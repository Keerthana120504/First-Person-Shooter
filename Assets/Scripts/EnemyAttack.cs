using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    // Private
    PlayerHealth target;
    [SerializeField] float damage = 20f;
    AudioManager audioManager;

    // Public 
    public Transform attackPoint;
    public float attackRange = 10f;
    public LayerMask playerLayer;

    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    // Start is called before the first frame update
    void Start()
    {
        target = FindAnyObjectByType<PlayerHealth>();
    }

    
    public void AttackHitEvent()
    {
        if (target == null) return;

        audioManager.chkPlaySFX(audioManager.zombieAttack);

        Collider[] hitplayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

        foreach (Collider player in hitplayer)
        {
            Debug.Log("Attacked the " + player.name);
            audioManager.PlaySFX(audioManager.hurt);
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
