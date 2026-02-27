using UnityEngine;

public class pipeBehaviour : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float deadZone = -15f;

    void Update()
    {
        transform.position = transform.position + (Vector3.left * moveSpeed) * Time.deltaTime;

        if (transform.position.x < deadZone)
        {
            Destroy(gameObject);
        }
    }
}
