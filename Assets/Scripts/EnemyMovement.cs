using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [field: SerializeField]
    public float speed { get; set; } = 2.0f;
    private Rigidbody2D rb;
    private bool movingUp = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 move = Vector2.zero;

        if (movingUp)
        {
            move.y += speed;
        }
        else
        {
            move.y -= speed;
        }

        rb.MovePosition(rb.position + (move * Time.deltaTime));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Wall")
        {
            movingUp = !movingUp;
        }
    }
}