using UnityEngine;

public class DamageOnTouch : MonoBehaviour
{
    public int damage = 1;
    public string targetTag = "Player";
    public bool destroySelfOnHit = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag(targetTag)) return;
        if (other.TryGetComponent(out Health h)) h.Damage(damage);
        if (destroySelfOnHit) Destroy(gameObject);
    }
}