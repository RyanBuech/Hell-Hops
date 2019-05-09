using UnityEngine;

public class Cloud : MonoBehaviour
{
    public float speed = 4.0f;
    public float maxRotationSpeed = 600.0f;

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(-speed, 0);
        rb.angularVelocity = Random.Range(-maxRotationSpeed, maxRotationSpeed);
    }

    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}