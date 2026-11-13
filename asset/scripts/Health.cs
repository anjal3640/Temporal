using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 3;
    public int Current { get; private set; }

    public UnityEvent<int> onDamaged;
    public UnityEvent onDeath;

    void Awake() => Current = maxHealth;

    public void Damage(int amount)
    {
        if (Current <= 0) return;
        Current -= amount;
        onDamaged?.Invoke(Current);
        if (Current <= 0) onDeath?.Invoke();
    }

    public void Heal(int amount) => Current = Mathf.Min(maxHealth, Current + amount);
}