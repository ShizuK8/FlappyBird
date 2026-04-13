using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 5f;
    public float leftLimit = -15f;


    private void Update()
    {
        transform.Translate(Vector2.left * speed * Time.deltaTime);
        if (transform.position.x < leftLimit)
            {
            Destroy(gameObject);
        }
    }
}
