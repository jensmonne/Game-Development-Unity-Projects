using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Vector2 movement;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        movement = new Vector2(moveX, moveY).normalized;

        if (movement.sqrMagnitude > 0.01f)
        {
            RotateCharacterToMovementDirection();
        }

        rb.linearVelocity = movement * speed;
        
        // ice physics
        //rb.AddForce(movement * (speed * Time.fixedDeltaTime), ForceMode2D.Impulse);
    }

    private void RotateCharacterToMovementDirection()
    {
        float angle = Mathf.Atan2(movement.y, movement.x) * Mathf.Rad2Deg;
        
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle - 90));
    }
}