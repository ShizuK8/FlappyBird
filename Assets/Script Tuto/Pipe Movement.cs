using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed = 2f;

    void Update()
    {
        // On vérifie si l'oiseau existe ET s'il est en train de jouer
        if (BirdController.instance != null && BirdController.instance.currentState == BirdController.GameState.Playing)
        {
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        // Si l'état n'est plus "Playing", le code au-dessus est ignoré et le tuyau s'arrête.
    }
}