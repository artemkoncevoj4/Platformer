using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Collectible : MonoBehaviour
{
    private void Awake()
    {
        var collider = GetComponent<CircleCollider2D>();
        collider.isTrigger = true;
        collider.radius = 0.3f;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleManager.Instance.Collect(this);
            Destroy(gameObject);
        }
    }
}