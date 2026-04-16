using UnityEngine;
using UnityEngine.InputSystem;
public class BirdController : MonoBehaviour
{
    public static BirdController instance;
    private Rigidbody2D rb;
    
    [Header("UI Settings")]
    public GameObject gameOverButton;
    public GameObject gameOverText;

    [Header("Bird Settings")]
    [Range(1f, 10f)]
    public float jumpForce = 5f;
    public enum GameState { Playing, GameOver }
    public GameState currentState = GameState.Playing;
    public int scoring = 0;
    void Awake()
    {
        instance = this;
    }
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
            if (currentState == GameState.Playing)
            {
                HandleInput();
            }
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, Mathf.Clamp(rb.linearVelocity.y, -10f, 10f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Obstacles") || collision.gameObject.CompareTag("Grass") || collision.gameObject.CompareTag("Sky"))
        {
            Debug.Log("Game Over");
            currentState = GameState.GameOver;
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
        if (currentState == GameState.GameOver)
        {
            jumpForce = 0f;
            Time.timeScale = 0f;
            gameOverButton.SetActive(true);
            gameOverText.SetActive(true);
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Score") && currentState == GameState.Playing)
        {
            Debug.Log("+ 1 point");
            scoring++;
        }

    }
    
    
}



