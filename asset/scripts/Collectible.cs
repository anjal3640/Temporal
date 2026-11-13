using UnityEngine;

public class Collectible : MonoBehaviour
{
    public int points = 1;
    public AudioClip sound;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.CompareTag("Player")) return;
        GameManager.I.AddScore(points);
        if (sound) AudioSource.PlayClipAtPoint(sound, transform.position);
        Destroy(gameObject);
    }
}