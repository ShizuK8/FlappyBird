using UnityEngine;
using UnityEngine.InputSystem;
public class BirdController : MonoBehaviour
{
              
    private Rigidbody2D rb;

    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;
    public enum GameState { Playing, GameOver }

    public GameState currentState = GameState.Playing;

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

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles") || collision.gameObject.CompareTag("Grass") || collision.gameObject.CompareTag("Sky"))
        {
            Debug.Log("Game Over");
            currentState = GameState.GameOver;
            rb.linearVelocity = Vector2.zero;
        }
        if (collision.gameObject.CompareTag("Grass"))
        {
            Debug.Log("Tu viens de toucher de l'herbe, comme tous les gamers, tu as une alergie sévère à l'herbe et tu meurs");
        }
        if (collision.gameObject.CompareTag("Sky"))
        {
            Debug.Log("I Believe i can fly, I believe i can touch the S...");
        }
        if (collision.gameObject.CompareTag("Score"))
        {
            Debug.Log("+1 point");
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score") && currentState == GameState.Playing)
        {
            Debug.Log("+ 1 point");
        }
    }

}



