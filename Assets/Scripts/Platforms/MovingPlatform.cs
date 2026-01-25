using UnityEngine;

[RequireComponent(typeof(Rigidbody2D), typeof(BoxCollider2D))]
public class MovingPlatform : MonoBehaviour
{
    public enum MovementType
    {
        Horizontal,
        Vertical
    }

    [Header("Movement Settings")]
    public MovementType movementType = MovementType.Vertical;
    [Tooltip("Расстояние, на которое платформа движется от начальной позиции")]
    public float distance = 3f;
    [Tooltip("Скорость движения (юнитов в секунду)")]
    public float speed = 1.5f;

    private Vector3 startPosition;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Kinematic;
        rb.interpolation = RigidbodyInterpolation2D.Interpolate;

        startPosition = transform.position;

        var collider = GetComponent<BoxCollider2D>();
        collider.usedByEffector = true;
    }

    void FixedUpdate()
    {
        float offset = 0f;

        if (movementType == MovementType.Horizontal)
        {
            offset = Mathf.PingPong(Time.time * speed, distance);
            rb.MovePosition(startPosition + Vector3.right * offset);
        }
        else
        {
            offset = Mathf.PingPong(Time.time * speed, distance);
            rb.MovePosition(startPosition + Vector3.up * offset);
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }
}