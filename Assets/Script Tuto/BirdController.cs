using UnityEngine;
using UnityEngine.InputSystem;
public class BirdController : MonoBehaviour

    
{
    private Rigidbody2D _rigidbody2D;

    public float jumpForce;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        if (_rigidbody2D == null) Debug.LogError("Bird Controll, pas de rigidbody");
    }

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
        _rigidbody2D.AddForceY(jumpForce, ForceMode2D.Impulse);
        }
        
    }
}
