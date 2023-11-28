using System.Collections.Generic; 
using System.Collections;
using UnityEngine;

public class Powerup : MonoBehaviour
{
    public float speed = 40;
    public bool hasPowerup = false;
    private float powerUpStrength = 15.0f;
    private float powerupSpeedMultiplier = 4.0f;

   private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("powerup"))
    {
        hasPowerup = true;

        // Increase player speed during the power-up
        speed *= powerupSpeedMultiplier;

        Destroy(other.gameObject);

        StartCoroutine(PowerupCountdownRoutine());
    }
}


    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);

        // Decrease player speed after the power-up duration
        speed /= powerupSpeedMultiplier;

        hasPowerup = false;
    }

   private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("powerup") && hasPowerup)
    {
        
    }

    if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
    {
        // Handle collision with enemy
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

        enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        Debug.Log("Collided with: " + collision.gameObject.name + " With powerup set to " + hasPowerup);
    }
}

}
