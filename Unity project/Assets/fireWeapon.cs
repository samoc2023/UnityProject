using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    public LayerMask enemyLayer;  // Assign the enemy layer in the Unity Editor

    private Animator playerAnim;
    private float fireRate = 1.0f;
    private float nextFire = 0.0f;

    void Start()
    {
        // You can initialize any variables or components here
    }

    void Update()
    {
        // While the shoot button is pressed - reload
        if (Input.GetKey(KeyCode.J) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            GameObject projectile = Instantiate(projectilePrefab, transform.position, projectilePrefab.transform.rotation);

            // Assuming the bullet has a rigidbody, you can set its velocity to make it move forward
            Rigidbody projectileRb = projectile.GetComponent<Rigidbody>();
            if (projectileRb != null)
            {
                // Adjust the velocity as needed
                projectileRb.velocity = transform.forward * 10.0f;
            }
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            // Assuming bullets have a tag "Bullet"
            Destroy(collision.gameObject);
            
            // Check if the collided object is an enemy
            if (IsEnemy(collision.gameObject))
            {
                // Enemy is hit, make it disappear or do something else
                Destroy(collision.gameObject); // This will destroy the enemy, adjust as needed
            }
        }
    }

    private bool IsEnemy(GameObject obj)
    {
        // Check if the collided object is on the enemy layer
        return (enemyLayer.value & (1 << obj.layer)) != 0;
    }
}
