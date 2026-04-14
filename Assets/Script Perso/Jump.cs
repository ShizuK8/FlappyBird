using UnityEngine;

public class BirdJump : MonoBehaviour
{
    private Rigidbody2D rb;

    [Header("Paramètres de vol")]
    public float jumpForce = 5f;

    // On va récupérer la référence au script Borders pour savoir si l'oiseau est mort
    private Borders bordersScript;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bordersScript = GetComponent<Borders>();
    }

    void Update()
    {
        // On vérifie si :
        // 1. La touche Espace est pressée
        // 2. Le script Borders existe et l'oiseau n'est PAS mort
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (bordersScript != null && !bordersScript.isDead)
            {
                Jump();
            }
            // Si tu n'as pas encore mis le script Borders sur l'objet, 
            // cette ligne permet de tester le saut quand même :
            else if (bordersScript == null)
            {
                Jump();
            }
        }
    }

    void Jump()
    {
        // On utilise linearVelocity pour correspondre à ta version de Unity
        rb.linearVelocity = Vector2.up * jumpForce;
    }
}