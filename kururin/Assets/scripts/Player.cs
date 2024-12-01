using UnityEngine;

public class Player : MonoBehaviour
{
    
    public float maxVelocity = 10f;
    
    private Rigidbody2D _rigidBody;

    public Game gameScript;
    
    void Start()
    {
        _rigidBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        _rigidBody.rotation -= 2f;
        
        if (Input.GetAxis("Horizontal") > 0)
        {
            _rigidBody.AddForce(new Vector2(10, 0));
        }
        else if (Input.GetAxis("Horizontal") < 0)
        {
            _rigidBody.AddForce(new Vector2(-10, 0));
        }
        else
        {
            Vector2 velocity = _rigidBody.linearVelocity;
            velocity.x *= 0.96f;
            _rigidBody.linearVelocity = velocity;
        }

        if (Input.GetAxis("Vertical") > 0)
        {
            _rigidBody.AddForce(new Vector2(0, 10));
        }
        else if (Input.GetAxis("Vertical") < 0)
        {
            _rigidBody.AddForce(new Vector2(0, -10));
        }
        else
        {
            Vector2 velocity = _rigidBody.linearVelocity;
            velocity.y *= 0.96f;
            _rigidBody.linearVelocity = velocity;
        }
        
        ClampVelocity();
    }
    
    private void ClampVelocity()
    {
        Vector2 clampedVelocity = _rigidBody.linearVelocity;

        // Clamp the x velocity
        clampedVelocity.x = Mathf.Clamp(clampedVelocity.x, -maxVelocity, maxVelocity);
        
        // Clamp the y velocity, if you want to control vertical speed as well
        clampedVelocity.y = Mathf.Clamp(clampedVelocity.y, -maxVelocity, maxVelocity);

        _rigidBody.linearVelocity = clampedVelocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (gameScript != null)
        {
            if (collision.gameObject.CompareTag("HitWall"))
            {
                gameScript.hSignalActive = true;
            }

            if (collision.gameObject.CompareTag("Finish"))
            {
                gameScript.fSignalActive = true;
            }
        }
    }
}