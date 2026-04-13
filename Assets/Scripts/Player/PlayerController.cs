using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private Vector2 movement;

    public Vector2 LastDirection { get; private set; }
    public bool canMove = true;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!canMove)
        {
            movement = Vector2.zero;
            return;
        }

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.magnitude > 0.1f)
        {
            LastDirection = movement.normalized;
        }
    }

    void FixedUpdate()
    {
        rb.linearVelocity = movement.normalized * speed;
    }
}