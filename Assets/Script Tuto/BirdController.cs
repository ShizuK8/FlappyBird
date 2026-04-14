using UnityEngine;
using UnityEngine.InputSystem;
public class BirdController : MonoBehaviour
{

    private Rigidbody2D rb;

    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;


    void Jump()
    {
        rb.linearVelocity = Vector2.zero;
        rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
    }

    void HandleInput()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Jump();
        }
    }
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }


    void Update()
    {
        HandleInput();
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -10f, 10f));
    }
}

