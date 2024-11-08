using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    // Private
    AudioManager audioManager;
    [SerializeField] Transform target;
    NavMeshAgent navMeshAgent;
    [SerializeField] float chaseRange = 10f;

    NavMeshAgent navMeshgAgent;
    float distanceToTarget = Mathf.Infinity;
    bool isProvoked = false;

    bool isDead = false;


    // Public
    public float health = 100f;


    private void Awake()
    {
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
    }

    private void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Skip further updates if the enemy is dead
        if (isDead)
        {
            return;
        } 
        distanceToTarget = Vector3.Distance(target.position, transform.position);
        distanceToTarget -= 0.2f;
        // Debug.Log(distanceToTarget);
        if (isProvoked)
        {
            EngageTarget();
        }
        else if (distanceToTarget < chaseRange)
        {
            isProvoked = true;
        }

    }

    private void EngageTarget()
    {
        if (distanceToTarget >= navMeshAgent.stoppingDistance)
        {
            ChaseTarget();
        }
        if (distanceToTarget <= navMeshAgent.stoppingDistance)
        {
            AttackTarget();
        }
    }

    private void ChaseTarget()
    {
        
        if (navMeshAgent != null)
        {
            GetComponent<Animator>().SetBool("Attack", false);
            GetComponent<Animator>().SetTrigger("Move");
            navMeshAgent.SetDestination(target.position);
        }
    }

    private void AttackTarget()
    {
        Debug.Log("Attack Fun Called");
        GetComponent<Animator>().SetBool("Attack", true);
    }

    private void OnDrawGizmosSelected()
    {
        // Display the explosion radius when Selected
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, chaseRange);
    }

    public void TakeDamage(float damage)
    {
        GetComponent<Animator>().SetTrigger("Hurting");
        health -= damage;
        if (health <= 0f)
        {
            
            Die();
        }
        // GetComponent<Animator>().SetTrigger("Move");
    }

    void Die ()
    {
        if (isDead) return; // Prevent multiple calls to Die
        isDead = true; // Set isDead flag to true

        // Trigger die animation
        GetComponent<Animator>().SetTrigger("Die");
        audioManager.PlaySFX(audioManager.killComfirmed);

        // Disable the NavMeshAgent to stop movement
        navMeshAgent.enabled = false;

        // Disable gravity
        //GetComponent<Rigidbody>().useGravity = false;

        // Disable the collider to prevent further interactions
        //GetComponent<Collider>().enabled = false;

        // Destroy the object after 2 seconds to allow the animation to play
        Destroy(gameObject, 2f);
    }
}
