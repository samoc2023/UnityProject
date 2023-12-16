using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private GameObject enemyObject;
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    public int health = 100;
    public int attackDamage = 10;

    private void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        enemyAnim = GetComponent<Animator>();
    }

    private void Update()
    {
        // You can add attack logic here based on your game requirements
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    public void Attack()
    {
        // Add logic for enemy attacks here
        // For example, you can deal damage to the player or perform other actions
    }

    void Die()
    {
        // Perform any actions when the enemy dies
        Destroy(gameObject);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("bullet")) {
            Destroy(collision.gameObject);

        }
    }
}
