using UnityEngine;

public class EnemyController : MonoBehaviour
{
    private Rigidbody enemyRb;
    private Animator enemyAnim;
    public int health = 100;
    public int attackDamage = 10;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        //enemyAnim = GetComponent<Animator>();
        gameObject.tag = "enemy";
    }

    void Update()
    {

    }


    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {

        }
    }

    public void Attack()
    {
        // Add logic for enemy attacks here
        // For example, you can deal damage to the player or perform other actions
    }





    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {


            print("hit by bullet");
            Destroy(gameObject);
            transform.position = Vector3.zero;

        }
    }
}
