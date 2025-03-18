using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{
    [field: SerializeField]
    public float speed { get; set; } = 2.0f;
    private Rigidbody2D rb;
    private Animator animator;
    private int health = 3;
    private bool isInvincible = false;
    private float invincibilityDuration = 1.0f;
    private float invincibilityTimer = 0.0f;

    [field: SerializeField]
    public UnityEvent OnCollect { get; set; }
    [field: SerializeField]
    public UnityEvent OnHitEnemy { get; set; }
    [field: SerializeField]
    public UnityEvent OnDie { get; set; }

    Vector2 move = new Vector2();

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = rb.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        move = Vector2.zero;
        animator.SetBool("run", false);

        if (Input.GetKey(KeyCode.W))
        {
            move.y += speed;
            animator.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.A))
        {
            move.x -= speed;
            animator.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.D))
        {
            move.x += speed;
            animator.SetBool("run", true);
        }

        if (Input.GetKey(KeyCode.S))
        {
            move.y -= speed;
            animator.SetBool("run", true);
        }

        rb.MovePosition(rb.position + (move * Time.deltaTime));

        // Handle invincibility timer
        if (isInvincible)
        {
            invincibilityTimer -= Time.deltaTime;
            if (invincibilityTimer <= 0)
            {
                isInvincible = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Enemy" && !isInvincible)
        {
            health--;
            OnHitEnemy.Invoke();
            isInvincible = true;
            invincibilityTimer = invincibilityDuration;

            if (health <= 0)
            {
                this.gameObject.SetActive(false);
                OnDie.Invoke();
                // Handle player death (e.g., restart level, show game over screen, etc.)
            }
        }
    }
}