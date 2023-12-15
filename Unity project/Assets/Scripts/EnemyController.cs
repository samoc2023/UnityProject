using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Perform any actions when the enemy dies
        Destroy(gameObject);
    }
}
