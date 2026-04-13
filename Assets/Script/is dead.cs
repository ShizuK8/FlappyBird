using UnityEngine;
using UnityEngine.SceneManagement;
public class Borders : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool isDead = false;

    void Start()
    {
        // On r�cup�re le Rigidbody2D au lancement
        rb = GetComponent<Rigidbody2D>();
        bool isDead = false;
    }

    // Utilisation de OnCollisionEnter2D pour un jeu Flappy Bird classique
    void OnCollisionEnter2D(Collision2D collision)
    {
        // On v�rifie le Tag (attention aux majuscules/minuscules !)
        if (collision.gameObject.CompareTag("bordures") && !isDead)
        {
            GameOver();
        }
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            Debug.Log("You pressed R !");
            Scene activeScene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(activeScene.buildIndex);
        }

    }
    

    void GameOver()
    {
        isDead = true;

        // 1. On arr�te net le mouvement de l'oiseau
        rb.linearVelocity = Vector2.zero;

        // 2. On emp�che de nouvelles forces physiques de s'appliquer
        rb.simulated = false;
        Scene activeScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(activeScene.buildIndex);
        Debug.Log("Game Over !");



        // Ici, tu peux ajouter l'affichage de ton menu Game Over
        // ex: UIManager.instance.ShowGameOverScreen();
    }
}