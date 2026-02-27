using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float thrustStrength = 5f;
    public LogicManager logic;

    bool isThrusting = false;
    void Update()
    {
        isThrusting = Keyboard.current.spaceKey.isPressed || Pointer.current.press.isPressed;
        
    }
    private void FixedUpdate()
    {
        if (isThrusting)
        {
            rb.linearVelocity = Vector2.up * thrustStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        rb.simulated = false;
        logic.GameOver();

    }

    
}