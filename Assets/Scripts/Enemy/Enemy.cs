using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] private int startingHealth;
    public abstract int health { get; protected set; }

    private void Start()
    {
        health = startingHealth;
    }

    public void TakeDamage(int value)
    {
        health -= value;

        if(health <= 0)
        {
            Die();
        }
    }

    public void Die()
    {
        Destroy(gameObject);
    }
}
