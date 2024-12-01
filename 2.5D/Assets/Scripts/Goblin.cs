using UnityEngine;

public class Goblin : MonoBehaviour
{
    private Rigidbody2D rb;
    private Transform player;
    
    public float drag = 1f;
    public float speed = 2f;
    public float chaseSpeed = 3.5f;
    public float patrolRange = 3f;
    public float detectionRange = 5f;
    public int health = 2;
    
    private Vector2 initialPosition;
    private Vector2 patrolTarget;
    private bool isChasing;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        rb.linearDamping = drag;
        initialPosition = transform.position;
        patrolTarget = initialPosition + Vector2.right * patrolRange;
        
        player = GameObject.FindWithTag("Player").transform;
    }

    private void Update()
    {
        if (!player) return;

        float distanceToPlayer = Vector2.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isChasing = true;
        }
        else if (distanceToPlayer > detectionRange)
        {
            isChasing = false;
        }
    }

    private void FixedUpdate()
    {
        if (isChasing)
        {
            Vector2 direction = (player.position - transform.position).normalized;
            rb.linearVelocity = direction * chaseSpeed;
        }
        else
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        Vector2 direction = (patrolTarget - (Vector2)transform.position).normalized;
        rb.linearVelocity = direction * speed;

        if (Vector2.Distance(transform.position, patrolTarget) < 0.1f)
        {
            patrolTarget = (Vector2)transform.position == initialPosition ? initialPosition + Vector2.right * patrolRange : initialPosition;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Arrow"))
        {
            health -= 1;
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
