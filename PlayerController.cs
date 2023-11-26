using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
   
    private Rigidbody playerRb;
    private float gravityModifier = 2.0f;
    public float jumpForce;
    public float speed = 40;
    public float turnSpeed;
    public float horizontalInput;
    public float forwardInput;

    private Animator playerAnim;


    public bool gameOver;
    public bool isOnGround = true;
    private bool isLowEnough;



   public bool hasPowerup = false; 
   private float powerUpStrength = 15.0f;
   private float powerupSpeedMultiplier = 2.0f;


    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        Physics.gravity *= gravityModifier;
        playerAnim = GetComponent<Animator>();


    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        //forwardInput = Input.GetAxis("Vertical");

       
        //move player forward
        if (Input.GetKey(KeyCode.RightArrow)){
         transform.Translate(Vector3.forward * Time.deltaTime * speed);
            
        }

        //Turn Player
        if (Input.GetKey(KeyCode.UpArrow))
        {
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            // Rotates the car based on horizontal input
            transform.Rotate(Vector3.down, turnSpeed * horizontalInput * Time.deltaTime);
        }



        // While space is pressed , float up
        if (Input.GetKey(KeyCode.Space) && isOnGround)
        {
            playerRb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isOnGround = false;

            playerAnim.SetTrigger("Jump_trig");
        }

       




    }

    //private void OnCollisionEnter(Collision collision)
    //{
            //isOnGround = true;
        // if player hits Ground
        //if (collision.gameObject.CompareTag("Ground") && !gameOver)
        //{

            //Debug.Log("Game Over!");
        //}
   // }

  
private void OnTriggerEnter(Collider other)
{
    if (other.CompareTag("Powerup"))
    {
        hasPowerup = true;
        Destroy(other.gameObject);

        // Increase player speed during the power-up
        speed *= powerupSpeedMultiplier;

        StartCoroutine(PowerupCountdownRoutine());
    }
}

IEnumerator PowerupCountdownRoutine()
{
    yield return new WaitForSeconds(7);

     speed /= 2.0f;

    hasPowerup = false;
}

private void OnCollisionEnter(Collision collision)
{
    if (collision.gameObject.CompareTag("Enemy") && hasPowerup)
    {
        Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
        Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;

        enemyRigidbody.AddForce(awayFromPlayer * powerUpStrength, ForceMode.Impulse);
        Debug.Log("Collided with: " + collision.gameObject.name + " With powerup set to " + hasPowerup);
    }
}


}
