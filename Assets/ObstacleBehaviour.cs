using UnityEngine;

public class ObstacleBehaviour : MonoBehaviour
{
    public static float moveSpeed = 2f;
    public static float deadZone = -15f;

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
