using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireWeapon : MonoBehaviour
{
    public GameObject projectilePrefab;
    //public LayerMask enemyLayer;  // Assign the enemy layer in the Unity Editor

    private Animator playerAnim;
    private float fireRate = 1.0f;
    private float nextFire = 0.0f;

    void Start()
    {
        gameObject.tag = "bullet";

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

   
    
}
