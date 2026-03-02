using UnityEngine;
using UnityEngine.EventSystems;
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
        bool isOverUI = EventSystem.current.IsPointerOverGameObject() || (Input.touchCount > 0 && EventSystem.current.IsPointerOverGameObject(Input.GetTouch(0).fingerId));
        isThrusting = Keyboard.current.spaceKey.isPressed || Pointer.current.press.isPressed || Input.GetMouseButton(0) && !isOverUI;
        
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