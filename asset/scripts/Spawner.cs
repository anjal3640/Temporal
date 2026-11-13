using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] prefabs;
    public float interval = 2f;
    public Vector2 areaSize = new Vector2(10, 0);

    float timer;

    void Update()
    {
        if (GameManager.I != null && GameManager.I.IsGameOver) return;
        timer += Time.deltaTime;
        if (timer < interval) return;
        timer = 0;

        var prefab = prefabs[Random.Range(0, prefabs.Length)];
        Vector2 offset = new Vector2(
            Random.Range(-areaSize.x / 2, areaSize.x / 2),
            Random.Range(-areaSize.y / 2, areaSize.y / 2));
        Instantiate(prefab, (Vector2)transform.position + offset, Quaternion.identity);
    }

    void OnDrawGizmosSelected() =>
        Gizmos.DrawWireCube(transform.position, areaSize);
}