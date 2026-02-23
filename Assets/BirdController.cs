using UnityEngine;
using UnityEngine.InputSystem;
public class BirdController : MonoBehaviour
{
    public Rigidbody2D rb;
    public float flapStrength = 10f;

    void Update()
    {
        if (Keyboard.current.spaceKey.wasPressedThisFrame || Pointer.current.press.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * flapStrength;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision detected with: " + collision.gameObject.name);
        rb.simulated = false;
        Time.timeScale = 0f;

    }
}